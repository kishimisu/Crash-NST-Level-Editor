using Alchemy;

namespace Havok
{
    [ObjectAttr(4)]
    public class hkxVertexAnimationUsageMap : hkObject
    {
        public override uint Hash => 0x46f9168e;

        [FieldAttr(0)] public EDataUsage _use; // TYPE_ENUM, etype: DataUsage, subtype: TYPE_UINT16
        [FieldAttr(2)] public u8 _useIndexOrig; // TYPE_UINT8
        [FieldAttr(3)] public u8 _useIndexLocal; // TYPE_UINT8
    }
}