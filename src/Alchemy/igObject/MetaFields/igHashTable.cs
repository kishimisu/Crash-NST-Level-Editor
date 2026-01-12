using System.Reflection;

namespace Alchemy
{
    public abstract class igHashTable : igContainer { }

    [ObjectAttr(64, 8)]
    public abstract class igHashTable<K, V> : igHashTable where K : notnull
    {
        [FieldAttr(16)] public igMemoryRef<V?> _values = [];
        [FieldAttr(32)] public igMemoryRef<K?> _keys = [];
        [FieldAttr(48)] public int _hashItemCount = 0;
        [FieldAttr(52)] public bool _autoRehash = true;
        [FieldAttr(56)] public float _loadFactor = 0.5f;

        public Dictionary<K, V> Dict { get; private set; } = [];
        public bool RebuildDict { get; set; } = false;

        public V this[K key]
        {
            get => Dict[key];
            set => Dict[key] = value;
        }
        public List<K> Keys => Dict.Keys.ToList();
        public List<V> Values => Dict.Values.ToList();

        /// <summary>
        /// Add a new entry to the table
        /// </summary>
        public void Add(K key, V value)
        {
            _keys.Add(key);
            _values.Add(value);

            Dict.Add(key, value);
            RebuildDict = true;
        }

        /// <summary>
        /// Remove the entry with the given key from the table
        /// </summary>
        public void Remove(K key)
        {
            int idx = _keys.IndexOf(key);

            if (idx == -1)
            {
                Console.WriteLine($"Warning: key {key} not found in hash table.");
            }
            else
            {
                _keys[idx] = GetInvalidKey();
                _values[idx] = default;
            }

            Dict.Remove(key);
            RebuildDict = true;
        }
        
        /// <summary>
        /// Remove all entries from the table
        /// </summary>
        public void Clear()
        {
            Dict.Clear();
            _keys.Clear();
            _values.Clear();
            RebuildDict = true;
        }

        public override igObjectBase Clone(IgzFile? igz = null, IgzFile? dst = null, CloneMode mode = CloneMode.Deep, Dictionary<igObject, igObject>? clones = null)
        {
            igHashTable<K, V> clone = (igHashTable<K, V>)base.Clone(igz, dst, mode, clones);
            clone.Dict = new Dictionary<K, V>();
            clone.BuildDict();
            return clone;
        }
        
        public override void Parse(IgzReader reader)
        {
            base.Parse(reader);

            BuildDict();
        }

        public Dictionary<K, V> BuildDict(bool skipDuplicateKeys = false)
        {
            FieldInfo keysField = GetType().GetField("_keys")!;
            FieldInfo valuesField = GetType().GetField("_values")!;

            igMemoryRef<K> keys = (igMemoryRef<K>)keysField.GetValue(this)!;
            igMemoryRef<V> values = (igMemoryRef<V>)valuesField.GetValue(this)!;

            Dict.Clear();

            for (int i = 0; i < keys.Count; i++)
            {
                if (i >= values.Count) break;
                
                K key = keys[i];

                if (key == null || key.Equals(GetInvalidKey())) continue;
                if (key is igHandleMetaField handle && handle.Reference == null) continue;
                if (key is igKerningPairMetaField kp && kp._first == 0 && kp._second == 0) continue;
                if (key is igEnumMetaField em && (uint)em._value == 0xFAFAFAFA) continue;
                if (key is DotNetDataMetaField dm && dm._elementType == 1073741825) continue;

                if (skipDuplicateKeys && Dict.ContainsKey(key)) continue;

                Dict.Add(key, values[i]);
            }

            return Dict;
        }

        public override void Write(IgzWriter writer)
        {
            if (RebuildDict && (typeof(K) == typeof(u64) || typeof(K) == typeof(string) || typeof(K) == typeof(igObject)))
            {
                Console.WriteLine($"[igHashTable] Rebuilding key type: {typeof(K)} for {this}");
                
                int capacity = int.Max(_keys.Count, Dict.Count * 2);
                
                _keys.Clear();
                _values.Clear();
                _hashItemCount = Dict.Count;

                for (int i = 0; i < capacity; i++)
                {
                    _keys.Add(GetInvalidKey());
                    _values.Add(default);
                }

                foreach ((K key, V value) in Dict)
                {
                    uint hash = GetKeyHash(key) % (uint)capacity;
                    int index = FindEmptySlot(key, capacity);

                    _keys[index] = key;
                    _values[index] = value;
                }

                RebuildDict = false;
            }

            base.Write(writer);
        }

        private static K? GetInvalidKey()
        {
            object? flag = default;
            
            if (typeof(K) == typeof(u32)) flag = 0xFAFAFAFA;
            else if (typeof(K) == typeof(i32)) flag = unchecked((int)0xFAFAFAFA);
            else if (typeof(K) == typeof(u64)) flag = 0xFAFAFAFAFAFAFAFA;
            else if (typeof(K) == typeof(u16)) flag = (u16)0;

            return (K?)flag;
        }

        private static uint GetKeyHash(K key)
        {
            if (typeof(K) == typeof(string)) 
                return NamespaceUtils.ComputeHash((string)(object)key);
            
            if (typeof(K) == typeof(u64))
                return HashLong((ulong)(object)key);

            if (typeof(K) == typeof(igObject))
                return HashInt(key.GetHashCode());

            throw new Exception($"Unsupported key type: {typeof(K)}");
        }

        private static uint HashInt(int integer)
		{
			uint hash = (uint)(integer + (integer << 0xf));
			hash = (hash >> 10 ^ hash) * 9;
			hash = hash ^ hash >> 6;
			hash = hash + ~(hash << 0xb);
			return hash >> 0x10 ^ hash;
		}

        private static uint HashLong(ulong integer)
		{
			ulong hash = integer * 0x40000 + ~integer;
			hash = (hash >> 0x1f ^ hash) * 0x15;
			hash = (hash >> 0xb ^ hash) * 0x41;
			return (uint)(hash >> 0x16) ^ (uint)hash;
		}

        private int FindEmptySlot(K key, int count)
        {
            uint hash = GetKeyHash(key);
            int slot = (int)(hash % count);

            for (int i = 0; i < count; i++)
            {
                if (_keys[slot] == null || _keys[slot]!.Equals(GetInvalidKey()))
                    return slot;

                slot = (slot + 1) % count;
            }

            throw new Exception($"Failed to find empty slot for key {key}");
        }

        public override void RemoveChild(igObject child)
        {
            foreach ((K key, V value) in Dict.ToList())
            {
                if ((key is igObject k && k == child) || (value is igObject v && v == child) ||
                    (key is igHandleMetaField kh && kh.Reference != null && kh.Reference.objectName == child.ObjectName) ||
                    (value is igHandleMetaField vh && vh.Reference != null && vh.Reference.objectName == child.ObjectName))
                {
                    int index = _keys.IndexOf(key);

                    _keys[index] = GetInvalidKey();
                    _values[index] = default;

                    Dict.Remove(key);
                }
            }

            _hashItemCount = Dict.Count;
        }
    }
}
