using Alchemy;

namespace Havok
{
    [ObjectAttr(4)]
    public class hkcdStaticMeshTreeBasePrimitive : hkObject
    {
        public override uint Hash => 0x56da2f7c;

        [FieldAttr(0)] public u8 _indices_0; // TYPE_UINT8, arrsize: 4
        [FieldAttr(1)] public u8 _indices_1;
        [FieldAttr(2)] public u8 _indices_2;
        [FieldAttr(3)] public u8 _indices_3;
    }
}