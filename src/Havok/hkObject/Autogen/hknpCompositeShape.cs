using Alchemy;

namespace Havok
{
    [ObjectAttr(96)]
    public class hknpCompositeShape : hknpShape
    {
        public override uint Hash => 0x12bb3bef;

        [FieldAttr(48)] public hknpSparseCompactMapunsignedshort _edgeWeldingMap; // TYPE_STRUCT, ctype: hknpSparseCompactMapunsignedshort
        [FieldAttr(88)] public u32 _shapeTagCodecInfo; // TYPE_UINT32
    }
}