using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(96)]
    public class hkbHandIkDriverInfoHand : hkObject
    {
        public override uint Hash => 0x14dfe1dd;

        [FieldAttr(0)] public Vector4 _elbowAxisLS; // TYPE_VECTOR4
        [FieldAttr(16)] public Vector4 _backHandNormalLS; // TYPE_VECTOR4
        [FieldAttr(32)] public Vector4 _handOffsetLS; // TYPE_VECTOR4
        [FieldAttr(48)] public Quaternion _handOrienationOffsetLS; // TYPE_QUATERNION
        [FieldAttr(64)] public float _maxElbowAngleDegrees; // TYPE_REAL
        [FieldAttr(68)] public float _minElbowAngleDegrees; // TYPE_REAL
        [FieldAttr(72)] public i16 _shoulderIndex; // TYPE_INT16
        [FieldAttr(74)] public i16 _shoulderSiblingIndex; // TYPE_INT16
        [FieldAttr(76)] public i16 _elbowIndex; // TYPE_INT16
        [FieldAttr(78)] public i16 _elbowSiblingIndex; // TYPE_INT16
        [FieldAttr(80)] public i16 _wristIndex; // TYPE_INT16
        [FieldAttr(82)] public bool _enforceEndPosition; // TYPE_BOOL
        [FieldAttr(83)] public bool _enforceEndRotation; // TYPE_BOOL
        [FieldAttr(88)] public string _localFrameName; // TYPE_STRINGPTR
    }
}