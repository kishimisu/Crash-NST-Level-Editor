using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkRefCountedProperties : hkObject
    {
        public override uint Hash => 0x7c574867;

        [FieldAttr(0)] public hkMemory<hkRefCountedPropertiesEntry> _entries; // TYPE_ARRAY, ctype: hkRefCountedPropertiesEntry, subtype: TYPE_STRUCT
    }
}