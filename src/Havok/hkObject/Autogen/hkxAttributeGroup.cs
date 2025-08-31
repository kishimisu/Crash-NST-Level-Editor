using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkxAttributeGroup : hkObject
    {
        public override uint Hash => 0x345ca95d;

        [FieldAttr(0)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(8)] public hkMemory<hkxAttribute> _attributes; // TYPE_ARRAY, ctype: hkxAttribute, subtype: TYPE_STRUCT
    }
}