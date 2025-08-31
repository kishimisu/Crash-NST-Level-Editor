using Alchemy;

namespace Havok
{
    [ObjectAttr(112)]
    public class hkcdSimdTreeNode : hkcdFourAabb
    {
        public override uint Hash => 0xc4e406c7;

        [FieldAttr(96)] public u32 _data_0; // TYPE_UINT32, arrsize: 4
        [FieldAttr(100)] public u32 _data_1;
        [FieldAttr(104)] public u32 _data_2;
        [FieldAttr(108)] public u32 _data_3;
    }
}