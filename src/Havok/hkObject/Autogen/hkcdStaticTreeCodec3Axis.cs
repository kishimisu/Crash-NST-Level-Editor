using Alchemy;

namespace Havok
{
    [ObjectAttr(3)]
    public class hkcdStaticTreeCodec3Axis : hkObject
    {
        public override uint Hash => 0x4ad23f31;

        [FieldAttr(0)] public u8 _xyz_0; // TYPE_UINT8, arrsize: 3
        [FieldAttr(1)] public u8 _xyz_1;
        [FieldAttr(2)] public u8 _xyz_2;
    }
}