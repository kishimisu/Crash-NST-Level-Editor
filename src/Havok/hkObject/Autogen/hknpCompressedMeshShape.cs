using Alchemy;

namespace Havok
{
    [ObjectAttr(160)]
    public class hknpCompressedMeshShape : hknpCompositeShape
    {
        public override uint Hash => 0x5f60d536;

        [FieldAttr(96)] public hknpCompressedMeshShapeData _data; // TYPE_POINTER, ctype: hknpCompressedMeshShapeData, subtype: TYPE_STRUCT
        [FieldAttr(104)] public hkBitField _quadIsFlat; // TYPE_STRUCT, ctype: hkBitField
        [FieldAttr(128)] public hkBitField _triangleIsInterior; // TYPE_STRUCT, ctype: hkBitField
        [FieldAttr(152)] public i32 _numTriangles; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(156)] public i32 _numConvexShapes; // TYPE_INT32, flags: SERIALIZE_IGNORED
    }
}