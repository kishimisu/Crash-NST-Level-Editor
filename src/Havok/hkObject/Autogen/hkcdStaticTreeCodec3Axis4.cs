using Alchemy;

namespace Havok
{
    [ObjectAttr(4)]
    public class hkcdStaticTreeCodec3Axis4 : hkcdStaticTreeCodec3Axis
    {
        public override uint Hash => 0xd168bc2f;

        [FieldAttr(3)] public u8 _data; // TYPE_UINT8
    }
}