using Alchemy;

namespace Havok
{
    [ObjectAttr(5)]
    public class hkcdStaticTreeCodec3Axis5 : hkcdStaticTreeCodec3Axis
    {
        public override uint Hash => 0x12d67453;

        [FieldAttr(3)] public u8 _hiData; // TYPE_UINT8
        [FieldAttr(4)] public u8 _loData; // TYPE_UINT8
    }
}