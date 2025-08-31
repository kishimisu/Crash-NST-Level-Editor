using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkcdStaticTreeDynamicStoragehkcdStaticTreeCodec3Axis5 : hkObject
    {
        public override uint Hash => 0x926c0cf;

        [FieldAttr(0)] public hkMemory<hkcdStaticTreeCodec3Axis5> _nodes; // TYPE_ARRAY, ctype: hkcdStaticTreeCodec3Axis5, subtype: TYPE_STRUCT
    }
}