using System.Runtime.InteropServices;

namespace Alchemy
{
    public class IgzWriter
    {
        private List<MemoryStream> _streams = [];
        private List<BinaryWriter> _currentWriters = [];
        private List<MemoryPool> _memoryPools = [];

        private BinaryWriter _currentWriter;
        private MemoryPool _currentMemoryPool;
        
        private FixupCollection _fixups = new FixupCollection();
        private Dictionary<igObject, int> _objectOffsets = [];
        private bool _nextElementRefCounted = false;

        public int GetSize() => (int)_currentWriter.BaseStream.Length;
        public int GetPosition() => (int)_currentWriter.BaseStream.Position;
        public void Seek(int offset) => _currentWriter.Seek(offset, SeekOrigin.Begin);
        public MemoryPool GetCurrentMemoryPool() => _currentMemoryPool;

        // igObjectRef-specific
        public int GetObjectOffset(igObject obj) => _objectOffsets[obj];
        public bool IsObjectWritten(igObject obj) => _objectOffsets.ContainsKey(obj);
        public void SetObjectWritten(igObject obj, int offset) => _objectOffsets.Add(obj, offset);
        public bool RefCounted() => _nextElementRefCounted;
        public void SetRefCounted(bool refCounted) => _nextElementRefCounted = refCounted;

        /// <summary>
        /// Builds an IGZ file from a list of objects
        /// </summary>
        /// <param name="objects">The list of objects to include in the file</param>
        /// <param name="dependencies">The dependencies the objects in this file relies on</param>
        /// <returns>The newly built IGZ file as raw bytes</returns>
        public static byte[] BuildIGZ(List<igObject> objects, TDEP_Fixup dependencies)
        {
            return new IgzWriter().Build(objects, dependencies);
        }

        private byte[] Build(List<igObject> objects, TDEP_Fixup dependencies) 
        {
            using MemoryStream stream = new MemoryStream();
            using BinaryWriter writer = new BinaryWriter(stream);

            // Dump all objects data and build fixups
            byte[] objectsData = BuildObjects(objects);

            _fixups.TDEP.AddRange(dependencies);

            // Write fixups
            int fixupStart = ChunkInfo.Fixups.offset;
            writer.Seek(fixupStart, SeekOrigin.Begin);

            foreach (IFixup fixup in _fixups.GetAll())
            {
                fixup.Write(writer);
            }

            int fixupSize = (int)(writer.BaseStream.Position - fixupStart);
            int objectStart = fixupStart + fixupSize;

            // Write objects
            writer.Seek(objectStart, SeekOrigin.Begin);
            writer.Write(objectsData);

            // Build chunk infos from memory pools
            List<ChunkInfo> chunkInfos = 
            [ 
                new ChunkInfo { offset = fixupStart, size = fixupSize, alignment = 2048, identifier = 0 } 
            ];

            for (int i = 0; i < _memoryPools.Count; i++)
            {
                ChunkInfo last = chunkInfos.Last();
                MemoryPool memoryPool = _memoryPools[i];

                int offset = last.offset + last.size;
                int size = (int)_streams[i].Length;

                chunkInfos.Add(memoryPool.ToChunkInfo(offset, size));
            }
            
            // Write chunk infos
            writer.Seek(Marshal.SizeOf<IgzHeader>(), SeekOrigin.Begin);
            foreach (ChunkInfo chunkInfo in chunkInfos)
            {
                chunkInfo.Write(writer);
            }

            // Write header
            IgzHeader header = new IgzHeader(_fixups.GetActiveCount());
            writer.Seek(0, SeekOrigin.Begin);
            writer.WriteStruct(header);

            // Write memory pool names
            List<string> memoryPoolNames = _memoryPools.Select(m => m.name).Distinct().ToList();

            writer.Seek(0x224, SeekOrigin.Begin);
            foreach (string name in memoryPoolNames.Distinct())
            {
                if (name == "<ERROR>") Console.WriteLine("Memory pool name is <ERROR>");
                writer.WriteNullTerminatedString(name);
            }

            return stream.ToArray();
        }

        /// <summary>
        /// Dump objects fields and memories while building fixups
        /// </summary>
        /// <param name="objects">The list of objects to dump</param>
        /// <returns>The raw data containing all dumped objects</returns>
        private byte[] BuildObjects(List<igObject> objects)
        {
            MemoryPool defaultMemoryPool = objects[0].GetMemoryPool();

            var objectList = (igObjectList?)objects.FirstOrDefault(e => e.GetType() == typeof(igObjectList));
            var nameList     = (igNameList?)objects.FirstOrDefault(e => e.GetType() == typeof(igNameList));
            var nameListNSPC = (igNameList?)objects.Where(e => e.GetType() == typeof(igNameList)).Skip(1).FirstOrDefault();

            List<igObject> allObjects = FindAllObjectsRecursive(objects, []);
            List<igObject> namedObjects = objects.Where(e => e.GetObjectName() != null).ToList();

            // Update object list

            if (objectList == null)
            {
                objectList = new igObjectList();
                objectList.SetMemoryPool(defaultMemoryPool);
                objectList._data.SetMemoryPool(defaultMemoryPool);
                objectList._data.SetDataMemoryPool(defaultMemoryPool);
                allObjects.Insert(0, objectList);
            }
            objectList._count = namedObjects.Count;
            objectList._capacity = namedObjects.Count;

            objectList._data.Clear();
            objectList._data.AddRange(namedObjects);
            objectList._data.SetActive(namedObjects.Count > 0);
            
            // Update name list

            if (namedObjects.Count > 0)
            {
                if (nameList == null)
                {
                    nameList = new igNameList();
                    nameList.SetMemoryPool(defaultMemoryPool);
                    nameList._data.SetMemoryPool(defaultMemoryPool);
                    nameList._data.SetDataMemoryPool(defaultMemoryPool);
                    allObjects.Add(nameList);
                }
                nameList._count = namedObjects.Count;
                nameList._capacity = namedObjects.Count;

                nameList._data.Clear();
                nameList._data.AddRange(namedObjects.Select(e => new igNameMetaField(e.GetObjectName()!)).ToList());
            }
            else
            {
                nameList = null;
            }

            UpdateReferenceCount(allObjects);

            // Write all objects
            objectList.Write(this);
            nameList?.Write(this);
            nameListNSPC?.Write(this);

            // Build TMET, MTSZ and RVTB fixups
            foreach((igObject obj, int value) in _objectOffsets)
            {
                MemoryPool memoryPool = obj.GetMemoryPool()!;
                int offset = _objectOffsets[obj];

                SetMemory(memoryPool);
                _currentWriter!.Seek(offset,  SeekOrigin.Begin);
                
                Type? metaObjectType = AttributeUtils.GetBaseMetaObjectType(obj);
                Type objectType = metaObjectType ?? obj.GetType();

                _currentWriter.Write((uint)AddTMET(objectType));

                _fixups.RVTB.Add(EncodeOffset(value, memoryPool));
            }

            // Build ROOT, ONAM and NSPC fixups
            _fixups.ROOT.Add(_objectOffsets[objectList]);

            if (nameList != null)
                _fixups.ONAM.Add(_objectOffsets[nameList]);

            if (nameListNSPC != null) 
                _fixups.NSPC.Add(_objectOffsets[nameListNSPC]);

            return _streams.SelectMany(e => e.ToArray()).ToArray();
        }

        /// <summary>
        /// Find all objects recursively from a list of objects
        /// </summary>
        private List<igObject> FindAllObjectsRecursive(List<igObject> objects, HashSet<igObject> visited)
        {
            foreach (igObject obj in objects)
            {
                if (visited.Contains(obj)) continue;

                visited.Add(obj);

                FindAllObjectsRecursive(obj.GetChildren(), visited);
            }

            return visited.ToList();
        }

        /// <summary>
        /// Updates the reference count of all objects
        /// </summary>
        private void UpdateReferenceCount(List<igObject> objects)
        {
            foreach (igObject obj in objects)
            {
                obj.__referenceCount = 0;
            }

            foreach (igObject obj in objects)
            {
                foreach (igObject child in obj.GetChildren(ChildrenSearchParams.OnlyRefCounted))
                {
                    child.__referenceCount++;
                }
            }
        }

        /// <summary>
        /// Writes a value at a specific offset in the current memory pool (writer)
        /// </summary>
        public void Write(object? value, int offset)
        {
            if (value == null) return;

            Type type = value.GetType();

            _currentWriter.Seek(offset, SeekOrigin.Begin);

            // Scalar types
            if (AttributeUtils.WriteMethods.TryGetValue(type, out var writeMethod))
            {
                writeMethod(_currentWriter, value);
            }
            // igEnumMetaField
            else if (type.IsEnum)
            {
                Type underlyingType = Enum.GetUnderlyingType(type);
                Write(Convert.ChangeType(value, underlyingType), offset);
            }
            // igStringMetaField
            else if (value is string str)
            {
                _currentWriter.Write(AddTSTR(str, offset));
            }
            // igObjectRefMetaField
            else if (value is igObject obj)
            {
                obj.WriteAsObjectRef(this, offset);
            }
            // Other igMetaFields
            else if (value is igMetaField metaField)
            {
                metaField.Write(this);
            }
            // Arrays
            else if (type.IsArray)
            {
                Array array = (Array)value!;
                Type elementType = array.GetType().GetElementType()!;
                int elementSize = AttributeUtils.GetFieldSize(elementType);

                for (int i = 0; i < array.Length; i++)
                {
                    int elementOffset = offset + i * elementSize;
                    Write(array.GetValue(i), elementOffset);
                }
            }
            else
                throw new Exception("Failed to write value " + value + " on type " + type + "(" + value.GetType() + ")");
        }

        /// <summary>
        /// Set the current memory pool and returns its seek offset. 
        /// If it doesn't already exist, it will be created.
        /// </summary>
        /// <param name="memoryPool">The memory pool to set</param>
        /// <param name="alignment">(Optional) aligns the current memory pool offset</param>
        /// <returns>The memory pool's current offset</returns>
        public int SetMemory(MemoryPool memoryPool, int alignment = 0)
        {
            int memoryPoolIndex = GetOrCreateMemoryPool(memoryPool);
            
            _currentWriter = _currentWriters[memoryPoolIndex];
            _currentMemoryPool = _memoryPools[memoryPoolIndex];

            int offset = GetSize();

            if (memoryPoolIndex == 0 && alignment > 0)
            {
                offset += (alignment - (offset % alignment)) % alignment;
            }

            return offset;
        }

        /// <summary>
        /// Returns the index of a memory pool, and creates it if it doesn't exist
        /// </summary>
        private int GetOrCreateMemoryPool(MemoryPool memoryPool)
        {
            int index = _memoryPools.FindIndex(m => m.Equals(memoryPool));

            if (index != -1)
                return index;

            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);

            _streams.Add(stream);
            _currentWriters.Add(writer);
            _memoryPools.Add(memoryPool);

            return _memoryPools.Count - 1;
        }

        /// <summary>
        /// Reserves bytes in the current memory pool to fit the new size without advancing the offset
        /// </summary>
        /// <param name="newSize">The new size of the memory pool</param>
        public void ReserveBytes(int newSize)
        {
            const int alignment = 4;
            newSize += (alignment - (newSize % alignment)) % alignment;

            if (newSize > GetSize())
                _currentWriter.BaseStream.SetLength(newSize);
        }

        /// <summary>
        /// Encodes an offset for a memory pool
        /// </summary>
        /// <param name="offset">The local offset within the memory pool</param>
        /// <param name="memoryPool">The target memory pool</param>
        /// <returns>The encoded offset</returns>
        public int EncodeOffset(int offset, MemoryPool memoryPool)
        {
            int memoryIndex = _memoryPools.FindIndex(m => m.Equals(memoryPool));
            return (memoryIndex << 0x1B) | (offset & 0x7FFFFFF);
        }

        /// <summary>
        /// Adds a string to the TSTR fixup if it doesn't already exist.
        /// Also adds the string offset to the RSTT fixup.
        /// </summary>
        /// <param name="name">The string to add</param>
        /// <param name="offset">The current offset</param>
        /// <returns>The index of the string</returns>
        public int AddTSTR(string name, int offset)
        {
            int stringIndex = _fixups.TSTR.AddUnique(name);

            _fixups.RSTT.Add(offset);

            return stringIndex;
        }

        /// <summary>
        /// Adds a type to the TMET fixup if it doesn't already exist.
        /// Also adds the type size to the MTSZ fixup.
        /// </summary>
        /// <param name="type">The type to add</param>
        /// <returns>The index of the type</returns>
        public int AddTMET(Type type)
        {
            string typeName = type.Name;

            if (type == typeof(igMetaObjectInstance)) typeName = "igMetaObject";
            else if (typeName.EndsWith("MetaFieldInstance")) typeName = typeName.Replace("MetaFieldInstance", "MetaField");

            if (!_fixups.TMET.Contains(typeName))
            {
                _fixups.MTSZ.Add(AttributeUtils.GetObjectSize(type));
            }

            return _fixups.TMET.AddUnique(typeName);
        }

        /// <summary>
        /// Adds a handle reference to the EXNM fixup if it doesn't already exist.
        /// Also add corresponding missing TSTR entries.
        /// </summary>
        /// <param name="handle">The handle reference to add</param>
        /// <returns>The index of the handle</returns>
        public int AddHandleReference(NamedReference handle)
        {
            int index = _fixups.handleReferences.IndexOf(handle);
            
            if (index == -1)
            {
                _fixups.EXNM.Add(handle.ToHandleEXNM(_fixups.TSTR));
                _fixups.handleReferences.Add(handle);
                return _fixups.handleReferences.Count - 1;
            }

            return index;
        }

        /// <summary>
        /// Adds an object reference to the EXNM fixup if it doesn't already exist.
        /// Also add corresponding missing TSTR entries.
        /// </summary>
        /// <param name="handle">The object reference to add</param>
        /// <returns>The index of the handle</returns>
        public int AddObjectReference(NamedReference handle)
        {
            int index = _fixups.objectReferences.IndexOf(handle);
            
            if (index == -1)
            {
                _fixups.EXNM.Add(handle.ToObjectEXNM(_fixups.TSTR));
                _fixups.objectReferences.Add(handle);
                return _fixups.objectReferences.Count - 1;
            }

            return index;
        }

        /// <summary>
        /// Adds an external object reference to the EXID fixup if it doesn't already exist.
        /// </summary>
        /// <param name="handle">The object reference to add</param>
        /// <returns>The index of the EXID item</returns>
        public int AddEXID(NamedReference handle)
        {
            int index = _fixups.exidReferences.IndexOf(handle);
            
            if (index == -1)
            {
                _fixups.EXID.Add(handle.ToEXID());
                _fixups.exidReferences.Add(handle);
                return _fixups.exidReferences.Count - 1;
            }

            return index;
        }

        /// Adds offsets to the R-fixups
        public void AddROFS(int offset) => _fixups.ROFS.Add(EncodeOffset(offset, _currentMemoryPool));
        public void AddRPID(int offset) => _fixups.RPID.Add(EncodeOffset(offset, _currentMemoryPool));      
        public void AddREXT(int offset) => _fixups.REXT.Add(EncodeOffset(offset, _currentMemoryPool));
        public void AddRHND(int offset) => _fixups.RHND.Add(offset);
        public void AddRNEX(int offset) => _fixups.RNEX.Add(offset);
    }
}