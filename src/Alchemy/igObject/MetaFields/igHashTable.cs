using System.Reflection;

namespace Alchemy
{
    public abstract class igHashTable : igContainer { }

    [ObjectAttr(64, 8)]
    public abstract class igHashTable<K, V> : igHashTable where K : notnull
    {
        [FieldAttr(16)] public igMemoryRef<V?> _values = new();
        [FieldAttr(32)] public igMemoryRef<K?> _keys = new();
        [FieldAttr(48)] public int _hashItemCount = 0;
        [FieldAttr(52)] public bool _autoRehash = true;
        [FieldAttr(56)] public float _loadFactor = 0.5f;

        private Dictionary<K, V> _dict = new();

        public V this[K key]
        {
            get => _dict[key];
            set => _dict[key] = value;
        }
        public int Count => _dict.Count;
        public List<K> Keys => _dict.Keys.ToList();
        public List<V> Values => _dict.Values.ToList();
        public Dictionary<K, V> GetDict() => _dict;

        public override void Parse(IgzReader reader)
        {
            base.Parse(reader);

            FieldInfo keysField = GetType().GetField("_keys")!;
            FieldInfo valuesField = GetType().GetField("_values")!;

            igMemoryRef<K> keys = (igMemoryRef<K>)keysField.GetValue(this)!;
            igMemoryRef<V> values = (igMemoryRef<V>)valuesField.GetValue(this)!;

            for (int i = 0; i < keys.Count; i++)
            {
                K key = keys[i];

                if (key == null || key.Equals(GetInvalidKey())) continue;
                if (key is igHandleMetaField handle && !handle.HasData()) continue;
                if (key is igKerningPairMetaField kp && kp._first == 0 && kp._second == 0) continue;
                if (key is igEnumMetaField em && (uint)em._value == 0xFAFAFAFA) continue;
                if (key is DotNetDataMetaField dm && dm._elementType == 1073741825) continue;

                _dict.Add(key, values[i]);
            }
        }

        public K? GetInvalidKey()
        {
            object? flag = default;
            
            if (typeof(K) == typeof(u32)) flag = 0xFAFAFAFA;
            else if (typeof(K) == typeof(i32)) flag = unchecked((int)0xFAFAFAFA);
            else if (typeof(K) == typeof(u64)) flag = 0xFAFAFAFAFAFAFAFA;
            else if (typeof(K) == typeof(u16)) flag = (u16)0;

            return (K?)flag;
        }

        public override void Write(IgzWriter writer)
        {
            // TODO: rebuild hashtable from _dict
            base.Write(writer);
        }
    }
}
