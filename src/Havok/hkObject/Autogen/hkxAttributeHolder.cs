using Alchemy;

namespace Havok
{
    [ObjectAttr(32)]
    public class hkxAttributeHolder : hkReferencedObject
    {
        public override uint Hash => 0xfc72021b;

        [FieldAttr(16)] public hkMemory<hkxAttributeGroup> _attributeGroups; // TYPE_ARRAY, ctype: hkxAttributeGroup, subtype: TYPE_STRUCT
    }
}