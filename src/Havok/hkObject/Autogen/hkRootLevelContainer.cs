using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkRootLevelContainer : hkObject
    {
        public override uint Hash => 0x2772c11e;

        [FieldAttr(0)] public hkMemory<hkRootLevelContainerNamedVariant> _namedVariants; // TYPE_ARRAY, ctype: hkRootLevelContainerNamedVariant, subtype: TYPE_STRUCT
    }
}