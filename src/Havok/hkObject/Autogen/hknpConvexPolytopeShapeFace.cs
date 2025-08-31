using Alchemy;

namespace Havok
{
    [ObjectAttr(4)]
    public class hknpConvexPolytopeShapeFace : hkObject
    {
        public override uint Hash => 0xf3c05540;

        [FieldAttr(0)] public u16 _firstIndex; // TYPE_UINT16
        [FieldAttr(2)] public u8 _numIndices; // TYPE_UINT8
        [FieldAttr(3)] public u8 _minHalfAngle; // TYPE_UINT8
    }
}