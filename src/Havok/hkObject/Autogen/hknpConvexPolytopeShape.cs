using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(80)]
    public class hknpConvexPolytopeShape : hknpConvexShape
    {
        public override uint Hash => 0x3ce9b3e3;

        [FieldAttr(64)] public hkList<Vector4> _planes; // TYPE_RELARRAY, subtype: TYPE_VECTOR4
        [FieldAttr(68)] public hkList<hknpConvexPolytopeShapeFace> _faces; // TYPE_RELARRAY, ctype: hknpConvexPolytopeShapeFace, subtype: TYPE_STRUCT
        [FieldAttr(72)] public hkList<u8> _indices; // TYPE_RELARRAY, subtype: TYPE_UINT8
    }
}