using Alchemy;

namespace Havok
{
    [ObjectAttr(6)]
    public class hkcdStaticTreeCodec3Axis6 : hkcdStaticTreeCodec3Axis
    {
        public override uint Hash => 0x569b5d82;

        [FieldAttr(3)] public u8 _hiData; // TYPE_UINT8
        [FieldAttr(4)] public u16 _loData; // TYPE_UINT16
    }
}