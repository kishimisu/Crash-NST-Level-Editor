namespace Alchemy
{
    struct IgzHeader
    {
        public const u32 SIGNATURE = 0x49475A01;
        public const u32 VERSION = 10;
        public const u32 PLATFORM = 6;

        public u32 signature = SIGNATURE;
        public u32 version = VERSION;
        public u32 serializableFieldsHash = 0x444E5750;
        public u32 platform = PLATFORM;
        public u32 numFixups = 0;

        public IgzHeader(int numFixups) => this.numFixups = (u32)numFixups;
    }

    /// <summary>
    /// Class responsible for parsing an IGZ file as a List<igObject>.
    /// </summary>
    public class IgzReader : BinaryReader
    {
        private FixupCollection _fixups;
        private List<ChunkInfo> _chunkInfos = [];
        private Dictionary<int, igObject> _objects = []; // Global offset -> igObject
        private int objectsStartOffset;

        public TDEP_Fixup GetDependencies() => _fixups.TDEP;

        /// <summary>
        /// Parse an IGZ file and instanciate all of its objects
        /// </summary>
        /// <param name="stream">The stream containing the IGZ data</param>
        public IgzReader(MemoryStream stream) : base(stream) 
        {
            // Parse header
            stream.Seek(0, SeekOrigin.Begin);
            IgzHeader header = this.ReadStruct<IgzHeader>();

            // Parse chunk infos
            while (true)
            {
                ChunkInfo chunk = ChunkInfo.Parse(this);
                
                if (chunk.offset == 0) break;

                _chunkInfos.Add(chunk);
            }

            objectsStartOffset = _chunkInfos[1].offset;

            // Parse memory pool names
            this.Seek(0x224);
            ChunkInfo? lastChunk = null;
            foreach (ChunkInfo chunkInfo in _chunkInfos)
            {
                string memPoolName = lastChunk?.identifier == chunkInfo.identifier
                    ? lastChunk.name
                    : this.ReadNullTerminatedString();

                chunkInfo.name = memPoolName;
                lastChunk = chunkInfo;
            }

            // Parse fixups
            this.Seek(_chunkInfos[0].offset);
            _fixups = FixupCollection.Parse(this);

            // Optimization: pre-compute global offsets
            _fixups.GetAll().ForEach(f => 
            {
                if (f is not R_Fixup rFixup || f.GetName() == "RVTB" || f.GetName() == "ROOT") return;

                for (int i = 0; i < rFixup.Count; i++)
                {
                    rFixup[i] = GetGlobalOffset(rFixup[i]);
                }
            });

            // Initialize objects
            for (int i = 0; i < _fixups.RVTB.Count; i++)
            {
                // Get object offset
                int offset = _fixups.RVTB[i];
                int globalOffset = GetGlobalOffset(offset);

                // Get object type
                this.Seek(globalOffset);
                int typeIndex = ReadInt32();
                string typeName = _fixups.TMET[typeIndex];

                // Create object
                igObject obj = CreateRootObject(typeName, globalOffset);

                // Set memory pool
                obj.MemoryPool = GetMemoryPool(offset);
                
                _objects.Add(globalOffset, obj);
            }

            // Parse objects
            foreach ((int offset, igObject obj) in _objects)
            {
                this.Seek(offset);
                obj.Parse(this);
            }

            // Parse object names
            if (!_fixups.ROOT.IsEmpty() && !_fixups.ONAM.IsEmpty())
            {
                var objectList = (igObjectList)GetObject(_fixups.ROOT[0]);
                var nameList = (igNameList)GetObject(_fixups.ONAM[0]);

                for (int i = 0; i < objectList._data.Count; i++)
                {
                    igObject obj = objectList._data[i];
                    string? name = nameList._data[i].GetName();

                    obj.ObjectName = name;
                }
            }
        }
        
        /// <summary>
        /// Returns a list of all objects in the file, 
        /// sorted by order of appearance in the igObjectList
        /// </summary>
        /// <returns></returns>
        public List<igObject> GetObjects()
        {
            List<igObject> objects = _objects.Values.ToList();
            if (objects.Count == 0) return objects;

            igObjectList objectList = (igObjectList)_objects[GetGlobalOffset(_fixups.ROOT[0])];

            objects = objects.OrderBy(o =>
            {
                int index = objectList._data.IndexOf(o);
                return index == -1 ? int.MaxValue : index;
            }).ToList();

            objects.Remove(objectList);
            objects.Insert(0, objectList);

            if (_fixups.ONAM.Count > 0)
            {
                igNameList nameList = (igNameList)_objects[GetGlobalOffset(_fixups.ONAM[0])];
                objects.Remove(nameList);
                objects.Add(nameList);
            }

            if (_fixups.NSPC.Count > 0)
            {
                igNameList nspcList = (igNameList)_objects[GetGlobalOffset(_fixups.NSPC[0])];
                objects.Remove(nspcList);
                objects.Add(nspcList);
            }

            return objects;
        }

        /// <summary>
        /// Convert an encoded offset to a global offset
        /// </summary>
        /// <returns>The offset from the start of the file</returns>
        public int GetGlobalOffset(int offset)
        {
            // Optimization: return early if the offset is in the first chunk
            if (offset <= 0x7FFFFFF)
            {
                return objectsStartOffset + offset;
            }

            int chunkIndex = (offset >> 0x1B) + 1;

            return _chunkInfos[chunkIndex].offset + (offset & 0x7FFFFFF);
        }

        /// <summary>
        /// Returns the memory pool associated to an encoded offset
        /// </summary>
        public MemoryPool GetMemoryPool(int offset)
        {
            int chunkIndex = (offset >> 0x1B) + 1;

            return _chunkInfos[chunkIndex];
        }

        /// <summary>
        /// Checks if a fixup is active for a given offset
        /// </summary>
        /// <param name="fixup">The fixup name</param>
        /// <param name="globalOffset">The offset from the start of the file</param>
        /// <param name="removeFixup">(Optimization) Whether to remove the fixup from the list</param>
        /// <returns></returns>
        public bool IsFixupActive(string fixup, int globalOffset, bool removeFixup = true)
        {
            R_Fixup? rFixup = _fixups.GetR_Fixup(fixup);

            if (rFixup == null || rFixup.Count == 0) return false;

            int index = rFixup.IndexOf(globalOffset);

            if (index != -1)
            {
                if (removeFixup)
                    rFixup.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the igObject associated to an encoded offset
        /// </summary>
        public igObject GetObject(int offset)
        {
            int globalOffset = GetGlobalOffset(offset);
            return _objects[globalOffset];
        }

        /// <summary>
        /// Find an object reference in the fixups given its index.
        /// Used when parsing igHandleMetaFields.
        /// </summary>
        /// <param name="index">Decoded index</param>
        /// <param name="isHandle">Whether to search in handle references or EXID references</param>
        /// <returns>The object reference</returns>
        public NamedReference GetObjectReference(int index, bool isHandle)
        {
            return isHandle ? _fixups.handleReferences[index] : _fixups.exidReferences[index];
        }

        /// <summary>
        /// Create an empty instance of an igObject.
        /// Handle dynamic igMetaObjects.
        /// </summary>
        private igObject CreateRootObject(string className, int globalOffset)
        {
            if (className.EndsWith("MetaField")) className += "Instance"; // Hack to handle metafields that are instanced as root objects

            Type classType = Type.GetType("Alchemy." + className) 
                             ?? throw new Exception($"Class {className} not found.");

            // Handle dynamic objects
            if (CreateRootMetaObject(classType, globalOffset) is igObject dynamicObject)
            {
                return dynamicObject;
            }

            return (igObject)CreateEmptyInstance(classType);
        }

        /// <summary>
        /// Create an empty instance of an igMetaObject by reading its dynamic fields
        /// </summary>
        private igObject? CreateRootMetaObject(Type type, int globalOffset)
        {
            CachedObjectAttr objectAttributes = AttributeUtils.GetAttributes(type);
            
            if (!objectAttributes.IsBaseMetaObject()) return null;

            CachedFieldAttr _dynamicFieldMemory = objectAttributes.GetField("_dynamicFieldMemory")!;
            CachedFieldAttr _meta = objectAttributes.GetField("_meta")!;

            int rawRefOffset = _dynamicFieldMemory.GetOffset();
            int objectRefOffset = _meta.GetOffset();

            if (!IsFixupActive("ROFS", globalOffset + rawRefOffset, false)) return null;

            this.Seek(globalOffset + objectRefOffset);
            
            igMetaObject? meta = (igMetaObject?)ReadObjectRef(_meta.GetFieldType(), false);

            if (meta == null)
                throw new Exception("Could not initialize igMetaObject, meta is null");

            Type metaObjectType = meta.GetMetaObjectType();

            return (igObject)CreateEmptyInstance(metaObjectType);
        }

        /// <summary>
        /// Create an empty instance of a given Alchemy type
        /// </summary>
        private static igObjectBase CreateEmptyInstance(Type type)
        {
            if (!type.IsSubclassOf(typeof(igObjectBase)))
                throw new Exception($"Type {type} is not a subclass of igObjectBase.");

            if (type.IsGenericType)
            {
                Type genericTypeDefinition = type.GetGenericTypeDefinition();
                Type genericArgument = type.GetGenericArguments()[0];
                Type constructedType = genericTypeDefinition.MakeGenericType(genericArgument);
                type = constructedType;
            }

            object obj = Activator.CreateInstance(type) 
                         ?? throw new Exception($"Failed to create instance of type {type}.");

            return (igObjectBase)obj;
        }

        /// <summary>
        /// Read a value of a given type at the current position
        /// </summary>
        public object? ReadValue(Type type)
        {
            // Scalar types
            if (AttributeUtils.ReadMethods.TryGetValue(type, out var readMethod))
            {
                return readMethod(this);
            }

            // igEnumMetaField
            if (type.IsEnum)
            {
                return Enum.ToObject(type, ReadInt32());
            }

            // igStringMetaField
            if (type == typeof(string))
            {
                if (IsFixupActive("RSTT", (int)BaseStream.Position))
                {
                    int tstrIndex = ReadInt32();
                    return _fixups.TSTR[tstrIndex];
                }

                return null;
            }

            // igObjectRefMetaField
            if (type.IsAssignableTo(typeof(igObject)))
            {
                return ReadObjectRef(type);
            }

            // Other igMetaFields
            if (type.IsAssignableTo(typeof(igMetaField)))
            {
                igMetaField obj = (igMetaField)Activator.CreateInstance(type)!;
                obj.Parse(this);
                return obj;
            }

            throw new NotSupportedException($"Type {type} is not supported.");
        }

        /// <summary>
        /// Parse an igObjectRefMetaField at the current position
        /// </summary>
        /// <returns>The referenced object</returns>
        private igObject? ReadObjectRef(Type type, bool removeFixup = true)
        {
            int position = (int)BaseStream.Position;
            u64 value = ReadUInt64();

            igObject? objectRef = null;

            if (IsFixupActive("ROFS", position, removeFixup))
            {
                objectRef = GetObject((int)value);
            }
            else if (IsFixupActive("RNEX", position, removeFixup))
            {
                objectRef = (igObject)CreateEmptyInstance(type);
                objectRef.Reference = _fixups.objectReferences[(int)value].Clone();
            }
            else if (IsFixupActive("REXT", position, removeFixup))
            {
                objectRef = (igObject)CreateEmptyInstance(type);
                objectRef.Reference = _fixups.exidReferences[(int)value].Clone();
            }

            return objectRef;
        }
        
        /// <summary>
        /// Parse an ArrayMetaField at the current position
        /// </summary>
        /// <param name="obj">The parent object</param>
        /// <param name="field">The array field</param>
        public void ReadArray(igObjectBase obj, CachedFieldAttr field)
        {
            object? arrayObj = field.GetValue(obj);
            Type elementType = field.GetElementType()!;

            if (arrayObj == null)
            {
                field.SetValue(obj, Array.CreateInstance(elementType, 0));
                return;
            }

            Array array = (Array)arrayObj;
            int elementSize = AttributeUtils.GetFieldSize(elementType);
            int startOffset = (int)BaseStream.Position;

            for (int i = 0; i < array.Length; i++)
            {
                int elementOffset = startOffset + i * elementSize;
                this.Seek(elementOffset);

                object? childValue = ReadValue(elementType);
                array.SetValue(childValue, i);
            }
        }        
    }
}