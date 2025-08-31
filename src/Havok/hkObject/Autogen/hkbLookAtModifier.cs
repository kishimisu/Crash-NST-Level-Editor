using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(256)]
    public class hkbLookAtModifier : hkbModifier
    {
        public override uint Hash => 0x9ad8d4bb;

        [FieldAttr(96)] public Vector4 _targetWS; // TYPE_VECTOR4
        [FieldAttr(112)] public Vector4 _headForwardLS; // TYPE_VECTOR4
        [FieldAttr(128)] public Vector4 _neckForwardLS; // TYPE_VECTOR4
        [FieldAttr(144)] public Vector4 _neckRightLS; // TYPE_VECTOR4
        [FieldAttr(160)] public Vector4 _eyePositionHS; // TYPE_VECTOR4
        [FieldAttr(176)] public float _newTargetGain; // TYPE_REAL
        [FieldAttr(180)] public float _onGain; // TYPE_REAL
        [FieldAttr(184)] public float _offGain; // TYPE_REAL
        [FieldAttr(188)] public float _limitAngleDegrees; // TYPE_REAL
        [FieldAttr(192)] public float _limitAngleLeft; // TYPE_REAL
        [FieldAttr(196)] public float _limitAngleRight; // TYPE_REAL
        [FieldAttr(200)] public float _limitAngleUp; // TYPE_REAL
        [FieldAttr(204)] public float _limitAngleDown; // TYPE_REAL
        [FieldAttr(208)] public i16 _headIndex; // TYPE_INT16
        [FieldAttr(210)] public i16 _neckIndex; // TYPE_INT16
        [FieldAttr(212)] public bool _isOn; // TYPE_BOOL
        [FieldAttr(213)] public bool _individualLimitsOn; // TYPE_BOOL
        [FieldAttr(214)] public bool _isTargetInsideLimitCone; // TYPE_BOOL
        [FieldAttr(216)] public i16 _SensingAngle; // TYPE_INT16
        [FieldAttr(224)] public Vector4 _lookAtLastTargetWS; // TYPE_VECTOR4, flags: SERIALIZE_IGNORED
        [FieldAttr(240)] public float _lookAtWeight; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(244)] public bool _ikOn; // TYPE_BOOL, flags: SERIALIZE_IGNORED
    }
}