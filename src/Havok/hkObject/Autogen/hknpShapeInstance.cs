using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(128)]
    public class hknpShapeInstance : hkObject
    {
        public override uint Hash => 0x5e3dae05;

        [FieldAttr(0)] public Matrix4x4 _transform; // TYPE_TRANSFORM
        [FieldAttr(64)] public Vector4 _scale; // TYPE_VECTOR4
        [FieldAttr(80)] public hknpShape _shape; // TYPE_POINTER, ctype: hknpShape, subtype: TYPE_STRUCT
        [FieldAttr(88)] public u16 _shapeTag; // TYPE_UINT16
        [FieldAttr(90)] public u16 _destructionTag; // TYPE_UINT16
    }
}