using System.Collections;

namespace Alchemy
{
    public interface IMemoryRef
    {
        public int Count { get; }
    }

    public class igMemoryRef() : igMemoryRef<byte>() { }

    [ObjectAttr(16)]
    public class igMemoryRef<T> : igRefMetaField, IMemoryRef, IList<T>
    {
        [FieldAttr(0)] public int _size;
        [FieldAttr(4)] public int _bitfield = 0x01100000;
        [FieldAttr(8)] public igRawRefMetaField _ref = new();
        
        public MemoryPool MemoryPool { get; set; } = MemoryPool.Default;

        protected List<T> _elements = [];

        // List<T> interface
        public T this[int index]
        {
            get => _elements[index];
            set => _elements[index] = value;
        }
        public int Count => _elements.Count;
        public bool IsReadOnly => false;
        public void Add(T element) => _elements.Add(element);
        public void AddRange(List<T> elements) => _elements.AddRange(elements);
        public bool Any(Func<T, bool> predicate) => _elements.Any(predicate);
        public List<K> Cast<K>() => _elements.Cast<K>().ToList();
        public void Clear() => _elements.Clear();
        public bool Contains(T element) => _elements.Contains(element);
        public void CopyTo(T[] array, int arrayIndex) => _elements.CopyTo(array, arrayIndex);
        public T? Find(Predicate<T> predicate) => _elements.Find(predicate);
        public List<T> FindAll(Predicate<T> predicate) => _elements.FindAll(predicate);
        public T? FirstOrDefault() => _elements.FirstOrDefault();
        public IEnumerator<T> GetEnumerator() => _elements.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public int IndexOf(T element) => _elements.IndexOf(element);
        public void Insert(int index, T element) => _elements.Insert(index, element);
        public bool Remove(T element) => _elements.Remove(element);
        public void RemoveAt(int index) => _elements.RemoveAt(index);
        public IEnumerable<TOut> Select<TOut>(Func<T, TOut> selector) => _elements.Select(selector);
        public void Sort(Comparison<T> comparison) => _elements.Sort(comparison);
        public T[] ToArray() => _elements.ToArray();
        public List<T> ToList() => _elements.ToList();
        
        public void Set(List<T> elements) => _elements = elements;
        public List<T> GetElements() => _elements;

        // Bitfield manipulation
        public bool IsActive() => ((_bitfield >> 0x18) & 1) != 0;
        public void SetActive(bool active) => _bitfield = (_bitfield & ~(1 << 0x18)) | ((active ? 1 : 0) << 0x18);
        public int GetMemoryAlignment() => 1 << (((_bitfield >> 0x14) & 0xF) + 2);
        private void SetMemoryAlignment(int alignment)
        {
            int packedAlignment = int.Log2(int.Max(alignment, 4));
            _bitfield = (int)(_bitfield & 0xFF0FFFFF) | ((packedAlignment - 2 & 0xF) << 0x14);
        }

        public override igObjectBase Clone(IgzFile? igz = null, IgzFile? dst = null, CloneMode mode = CloneMode.Shallow, Dictionary<igObject, igObject>? clones = null)
        {
            igMemoryRef<T> clone = new();
            clone._size = _size;
            clone._bitfield = _bitfield;
            clone._ref = new();
            clone.MemoryPool = MemoryPool;

            if (!mode.HasFlag(CloneMode.Deep) || !typeof(T).IsSubclassOf(typeof(igObjectBase)))
            {
                clone._elements = new List<T>(_elements);
                return clone;
            }

            clone._elements = new List<T>(_elements.Count);
            for (int i = 0; i < _elements.Count; i++)
            {
                igObjectBase? element = _elements[i] as igObjectBase;
                object cloneElement = element?.Clone(igz, dst, mode, clones)!;
                clone._elements.Add((T)cloneElement);
            }
            return clone;
        }

        public override void Parse(IgzReader reader)
        {
            int startOffset = (int)reader.BaseStream.Position;
            
            _size = reader.ReadInt32();
            _bitfield = reader.ReadInt32();
            _ref._address = reader.ReadUInt64();

            int dataOffset = reader.GetGlobalOffset((int)_ref._address);
            int typeSize = AttributeUtils.GetFieldSize(typeof(T));
            int count = _size / typeSize;
            
            MemoryPool = reader.GetMemoryPool((int)_ref._address);

            if (typeof(T) == typeof(byte))
            {
                // Optimization for byte arrays
                reader.Seek(dataOffset);
                _elements = (List<T>)(object)new List<byte>(reader.ReadBytes(_size));
                return;
            }

            for (int i = 0; i < count; i++)
            {
                reader.Seek(dataOffset + i * typeSize);

                object value = reader.ReadValue(typeof(T))!;
                Add((T)value);
            }
        }

        public override void Write(IgzWriter writer)
        {
            int offset = writer.GetPosition();

            if (!IsActive())
            {
                // Inactive memory
                writer.AddRPID(offset);
                base.Write(writer);
                return;
            }

            // Active memory
            MemoryPool baseMemory = writer.GetCurrentMemoryPool();
            bool refCounted = writer.RefCounted();

            int typeSize = AttributeUtils.GetFieldSize(typeof(T));
            int memoryStart = writer.SetMemory(MemoryPool, GetMemoryAlignment());

            _size = _elements.Count * typeSize;
            _ref!._address = (u64)writer.EncodeOffset(memoryStart, MemoryPool);

            writer.ReserveBytes(memoryStart + _size);

            for (int i = 0; i < _elements.Count; i++)
            {
                T element = _elements[i];
                int elementOffset = memoryStart + typeSize * i;
                writer.SetRefCounted(refCounted);
                writer.Write(element, elementOffset);
            }

            writer.SetMemory(baseMemory);
            writer.Seek(offset);
            base.Write(writer);
        }

        public override List<igObject> GetChildren(ChildrenSearchParams searchParams)
        {
            if (!typeof(T).IsSubclassOf(typeof(igObjectBase))) return [];

            List<igObject> children = [];   

            foreach (T element in _elements)
            {
                children.AddRange(GetFieldChildren(element, searchParams));
            }

            return children;
        }

        public override List<NamedReference> GetHandles()
        {
            if (typeof(T) != typeof(igHandleMetaField)) return [];

            List<NamedReference> references = [];

            foreach (T element in _elements)
            {
                references.AddRange((element as igHandleMetaField)!.GetHandles());
            }

            return references;
        }

        public override void RemoveChild(igObject child)
        {
            if (typeof(T) == typeof(igHandleMetaField))
            {
                foreach (T element in _elements.ToList())
                {
                    igHandleMetaField? handle = element as igHandleMetaField;
                    if (handle == null) continue;

                    if (handle.Reference != null && handle.Reference.objectName == child.ObjectName)
                    {
                        _elements.Remove(element);
                    }
                }
            }
            else if (typeof(T).IsAssignableTo(typeof(igObject)))
            {
                foreach (T element in _elements.ToList())
                {
                    igObject? obj = element as igObject;

                    if (obj == child)
                    {
                        _elements.Remove(element);
                    }
                }
            }
        }
    }

    /// <summary>
    /// (VSC-file specific) Used to define an igMemoryRef which contains a single 
    /// element inlined inside the _ref field instead of a pointer to a memory pool.
    /// </summary>
    public class InlinedMemoryRef<T> : igMemoryRef<T> 
    {
        public override void Parse(IgzReader reader)
        {
            _size = reader.ReadInt32();
            _bitfield = reader.ReadInt32();

            Add((T)reader.ReadValue(typeof(T))!); // read element in _ref
        }

        public override void Write(IgzWriter writer)
        {
            int offset = writer.GetPosition();
            
            writer.Write(_size, offset);
            writer.Write(_bitfield, offset + 4);
            writer.Write(_elements.FirstOrDefault(), offset + 8); // inline element in _ref
        }
    }
}
