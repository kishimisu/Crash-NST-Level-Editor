namespace Alchemy
{
    [ObjectAttr(576, 16)]
    public class CMotorcycleCamera : CConstrainedCamera
    {
        [FieldAttr(432)] public igHandleMetaField _splineEntity = new();
        [FieldAttr(440)] public igHandleMetaField _focusedEntity = new();
        [FieldAttr(448)] public float _distanceAlongSpline;
        [FieldAttr(452)] public igVec3fMetaField _rotationVelocity = new();
        [FieldAttr(464)] public igVec3fMetaField _lastSplineForward = new();
        [FieldAttr(476)] public igVec3fMetaField _lastValidForward = new();
        [FieldAttr(488)] public float _forwardFollowAngle = 38.0f;
        [FieldAttr(492)] public float _rotationDamping = 0.088f;
        [FieldAttr(496)] public igVec3fMetaField _lastPosition = new();
        [FieldAttr(508)] public igVec3fMetaField _positionVelocity = new();
        [FieldAttr(520)] public float _positionDamping = 1.0f;
        [FieldAttr(524)] public igVec2fMetaField _positionOffsetFromPlayer = new();
        [FieldAttr(532)] public float _cameraFollowPitch = -19.0f;
        [FieldAttr(536)] public float _cameraRampPitch = -25.0f;
        [FieldAttr(540)] public bool _rampPitchingActive;
        [FieldAttr(544)] public float _lastPitch;
        [FieldAttr(548)] public float _pitchVelocity;
        [FieldAttr(552)] public float _pitchDamping = 1.0f;
        [FieldAttr(556)] public bool _cameraUpdateActive = true;
        [FieldAttr(557)] public bool _cameraVerticalLocked;
        [FieldAttr(560)] public float _verticalLockedPositionDamping = 0.5f;
        [FieldAttr(564)] public float _cameraGroundHeight;
    }
}
