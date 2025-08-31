namespace Alchemy
{
    [ObjectAttr(592, 16)]
    public class CSplineCamera : CConstrainedCamera
    {
        [FieldAttr(432)] public igHandleMetaField _splineEntity = new();
        [FieldAttr(440)] public CSplineCameraData? _data;
        [FieldAttr(448)] public float _distanceFromPlayer;
        [FieldAttr(452)] public float _desiredDistanceFromPlayer;
        [FieldAttr(456)] public float _distanceAlongSpline;
        [FieldAttr(460)] public float _offsetFromSpline;
        [FieldAttr(464)] public bool _isVerticalSection;
        [FieldAttr(468)] public int _ignoredAxis = 2;
        [FieldAttr(472)] public float _distanceFromPlayerVelocity;
        [FieldAttr(476)] public igVec3fMetaField _rotationVelocity = new();
        [FieldAttr(488)] public igVec3fMetaField _inputRotationVelocity = new();
        [FieldAttr(500)] public float _distanceAlongSplineVelocity;
        [FieldAttr(504)] public float _offsetFromSplineVelocity;
        [FieldAttr(508)] public EPlayerId _playerId;
        [FieldAttr(512)] public bool _hasTargetMovedOnce;
        [FieldAttr(516)] public igVec3fMetaField _targetStartPosition = new();
        [FieldAttr(528)] public float _pitchOffset;
        [FieldAttr(532)] public ESplineMode _currentSplineCameraMode;
        [FieldAttr(536)] public CTimer? _directionalOffsetTimer;
        [FieldAttr(544)] public CTimer? _pitchOffsetTimer;
        [FieldAttr(552)] public CTransformMetaField _inputTransform = new();
    }
}
