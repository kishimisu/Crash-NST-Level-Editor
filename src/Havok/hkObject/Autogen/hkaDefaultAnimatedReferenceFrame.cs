using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(96)]
    public class hkaDefaultAnimatedReferenceFrame : hkaAnimatedReferenceFrame
    {
        public override uint Hash => 0x60f8e0b8;

        [FieldAttr(32)] public Vector4 _up; // TYPE_VECTOR4
        [FieldAttr(48)] public Vector4 _forward; // TYPE_VECTOR4
        [FieldAttr(64)] public float _duration; // TYPE_REAL
        [FieldAttr(72)] public hkMemory<Vector4> _referenceFrameSamples; // TYPE_ARRAY, subtype: TYPE_VECTOR4
    }
}