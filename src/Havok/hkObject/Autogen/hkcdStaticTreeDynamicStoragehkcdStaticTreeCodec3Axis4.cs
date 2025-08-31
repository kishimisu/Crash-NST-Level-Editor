using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkcdStaticTreeDynamicStoragehkcdStaticTreeCodec3Axis4 : hkObject
    {
        public override uint Hash => 0x27cc0eb4;

        [FieldAttr(0)] public hkMemory<hkcdStaticTreeCodec3Axis4> _nodes; // TYPE_ARRAY, ctype: hkcdStaticTreeCodec3Axis4, subtype: TYPE_STRUCT
    }
}