using System.Reflection;

namespace Alchemy
{
    /// <summary>
    /// Attributes that describe an Alchemy object
    /// </summary>
    public class ObjectAttr : Attribute
    {
        public int? size_nst { get; } // Object size (NST PC)
        public int? size_ctr { get; } // Object size (CTRNF PS4)

        public int alignment { get; } // Object alignment

        public bool metaObject { get; } // Dynamic object?
        public Type? baseMetaType { get; } // Base metaObject type

        public bool hashTableKeysRefCounted { get; } // Hashtable key/value ref count
        public bool hashTableValuesRefCounted { get; }

        public ObjectAttr(
            int size = -1,
            int nst = -1, 
            int ctr = -1, 
            int align = 4,
            bool meta = false, 
            Type? metaType = null, 
            bool refCountKeys = true, 
            bool refCountValues = true
        ) {
            if (size != -1) // [ObjectAttr(40, 8)]
            {
                size_nst = size;
                size_ctr = size;
                if (nst != -1) align = nst;
            }
            else // [ObjectAttr(nst: 40, ctr: 48)]
            {
                size_nst = nst != -1 ? nst : null;
                size_ctr = ctr != -1 ? ctr : null;
            }

            alignment = align;
            metaObject = meta;
            baseMetaType = metaType;
            hashTableKeysRefCounted = refCountKeys;
            hashTableValuesRefCounted = refCountValues;
        }
    }

    /// <summary>
    /// Attributes that describe a field within an Alchemy object
    /// </summary>
    public class FieldAttr : Attribute
    {
        public int? offset_nst { get; } // Field offset (NST PC)
        public int? offset_ctr { get; } // Field offset (CTRNF PS4)

        public bool refCounted { get; set; } // Include in reference count?
        public int bitfieldSize { get; } // (Bitfields only) size in bits

        /// <summary>
        /// Regular field constructor
        /// </summary>
        public FieldAttr(int offset = -1, int nst = -1, int ctr = -1, int size = -1, bool refCount = true)
        {
            if (offset != -1) // [FieldAttr(16)]
            {
                offset_nst = offset;
                offset_ctr = offset;
            }
            else // [FieldAttr(nst: 16, ctr: 24)]
            {
                offset_nst = nst != -1 ? nst : null;
                offset_ctr = ctr != -1 ? ctr : null;
            }

            if (size != -1)
            {
                bitfieldSize = size;
            }

            refCounted = refCount;
        }
    }

    /// <summary>
    /// Cached attributes and reflection data for an Alchemy object
    /// </summary>
    public class CachedObjectAttr
    {
        private readonly ObjectAttr _attr;
        private readonly List<CachedFieldAttr> _fields;
        private readonly List<CachedFieldAttr> _fieldsNST;
        private readonly List<CachedFieldAttr> _fieldsCTRNF;
        private readonly Type _type;

        public int GetAlignment() => _attr.alignment;
        public CachedFieldAttr? GetField(string name) => _fields.Find(f => f.GetName() == name);

        public bool IsBaseMetaObject() => _attr.metaObject;
        public Type? GetBaseMetaObjectType() => _attr.baseMetaType;
        public bool HashTableKeysRefCounted() => _attr.hashTableKeysRefCounted;
        public bool HashTableValuesRefCounted() => _attr.hashTableValuesRefCounted;

        public CachedObjectAttr(Type type, List<CachedFieldAttr> fields)
        {
            _type = type;
            _attr = type.GetCustomAttribute<ObjectAttr>(false)!;
            _fields = fields;
            _fieldsNST = _fields.Where(f => f.GameVersions.HasFlag(GameVersion.NST)).ToList();
            _fieldsCTRNF = _fields.Where(f => f.GameVersions.HasFlag(GameVersion.CTR)).ToList();

            // Propagate refCounted property for classes extending igHashTable
            if (type.BaseType?.IsGenericType == true && type.BaseType.GetGenericTypeDefinition() == typeof(igHashTable<,>))
            {
                GetField("_keys")!.SetRefCounted(_attr.hashTableKeysRefCounted);
                GetField("_values")!.SetRefCounted(_attr.hashTableValuesRefCounted);            
            }
        }

        public IReadOnlyList<CachedFieldAttr> GetFields(GameVersion version)
        {
            if (version == GameVersion.NST)
            {
                return _fieldsNST;
            }
            
            if (version == GameVersion.CTR)
            {
                return _fieldsCTRNF;
            }

            return _fields;
        }

        public int GetSize(GameVersion version)
        {
            if (version == GameVersion.NST && _attr.size_nst != null)
            {
                return _attr.size_nst.Value;
            }

            if (version == GameVersion.CTR && _attr.size_ctr != null)
            {
                return _attr.size_ctr.Value;
            }

            Console.WriteLine($"[Warning] Object size not defined for {_type} ({version})");
            
            return _attr.size_nst ?? _attr.size_ctr ?? 0;
        }
    }
    
    /// <summary>
    /// Cached attributes and reflection data for a field
    /// </summary>
    public class CachedFieldAttr
    {
        public GameVersion GameVersions = GameVersion.None;

        private readonly FieldInfo _info;
        private readonly FieldAttr _attr;

        public int GetBitFieldSize() => _attr.bitfieldSize;
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

            if (_attr.offset_nst != null) GameVersions |= GameVersion.NST;
            if (_attr.offset_ctr != null) GameVersions |= GameVersion.CTR;
            if (GameVersions == GameVersion.None) throw new Exception(GetName());
        }

        public int GetOffset(GameVersion version)
        {
            if (version == GameVersion.NST && _attr.offset_nst != null)
            {
                return _attr.offset_nst.Value;
            }

            if (version == GameVersion.CTR && _attr.offset_ctr != null)
            {
                return _attr.offset_ctr.Value;
            }

            throw new Exception($"Field offset not defined ({version})");
        }
    }
}