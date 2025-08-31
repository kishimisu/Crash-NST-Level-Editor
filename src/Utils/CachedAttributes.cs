using System.Reflection;

namespace Alchemy
{
    /// <summary>
    /// Attributes that describe an Alchemy object
    /// </summary>
    public class ObjectAttr : Attribute
    {
        public int size { get; } // Object size in bytes
        public int alignment { get; } // Object alignment for writing

        public bool metaObject { get; } // Dynamic object?
        public Type? baseMetaType { get; } // Base metaObject type

        public bool hashTableKeysRefCounted { get; }
        public bool hashTableValuesRefCounted { get; }

        public ObjectAttr(
            int size, 
            int alignment = 4, 
            bool metaObject = false, 
            Type? metaType = null, 
            bool keysRefCounted = true, 
            bool valuesRefCounted = true
        ) {
            this.size = size;
            this.alignment = alignment;
            this.metaObject = metaObject;
            this.baseMetaType = metaType;
            this.hashTableKeysRefCounted = keysRefCounted;
            this.hashTableValuesRefCounted = valuesRefCounted;
        }
    }

    /// <summary>
    /// Attributes that describe a field within an Alchemy object
    /// </summary>
    public class FieldAttr : Attribute
    {
        public int offset { get; } // Field offset
        public bool refCounted { get; set; } // Include in reference count?
        public int size { get; } // (Bitfields only) size in bits

        /// <summary>
        /// Regular field constructor
        /// </summary>
        public FieldAttr(int offset, bool refCounted = true)
        {
            this.offset = offset;
            this.refCounted = refCounted;
        }

        /// <summary>
        /// Bitfield constructor
        /// </summary>
        public FieldAttr(int offset, int size)
        {
            this.offset = offset;
            this.size = size;
        }
    }

    /// <summary>
    /// Cached attributes and reflection data for an Alchemy object
    /// </summary>
    public class CachedObjectAttr
    {
        private ObjectAttr _attr;
        private List<CachedFieldAttr> _fields;

        public int GetSize() => _attr.size;
        public int GetAlignment() => _attr.alignment;
        public List<CachedFieldAttr> GetFields() => _fields;
        public CachedFieldAttr? GetField(string name) => _fields.FirstOrDefault(f => f.GetName() == name);

        public bool IsBaseMetaObject() => _attr.metaObject;
        public Type? GetBaseMetaObjectType() => _attr.baseMetaType;
        public bool HashTableKeysRefCounted() => _attr.hashTableKeysRefCounted;
        public bool HashTableValuesRefCounted() => _attr.hashTableValuesRefCounted;

        public CachedObjectAttr(Type type, List<CachedFieldAttr> fields)
        {
            _attr = type.GetCustomAttribute<ObjectAttr>(false)!;
            _fields = fields;

            // Propagate refCounted property for classes extending igHashTable
            if (type.BaseType?.IsGenericType == true && type.BaseType.GetGenericTypeDefinition() == typeof(igHashTable<,>))
            {
                GetField("_keys")!.SetRefCounted(_attr.hashTableKeysRefCounted);
                GetField("_values")!.SetRefCounted(_attr.hashTableValuesRefCounted);            
            }
        }
    }
    
    /// <summary>
    /// Cached attributes and reflection data for a field
    /// </summary>
    public class CachedFieldAttr
    {
        private FieldInfo _info;
        private FieldAttr _attr;

        public int GetOffset() => _attr.offset;
        public int GetBitFieldSize() => _attr.size;
        public bool RefCounted() => _attr.refCounted;
        public void SetRefCounted(bool refCounted) => _attr.refCounted = refCounted;
        public string GetName() => _info.Name;
        public Type GetFieldType() => _info.FieldType;
        public Type? GetElementType() => _info.FieldType.GetElementType();
        public bool IsArray() => _info.FieldType.IsArray;

        public object? GetValue(object obj) => _info.GetValue(obj);
        public void SetValue(object obj, object? value) => _info.SetValue(obj, value);

        public CachedFieldAttr(FieldInfo info)
        {
            _info = info;
            _attr = info.GetCustomAttribute<FieldAttr>(false)!;
        }
    }
}