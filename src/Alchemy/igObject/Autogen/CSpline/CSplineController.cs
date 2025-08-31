namespace Alchemy
{
    [ObjectAttr(288, 16)]
    public class CSplineController : CBaseMovementController
    {
        [FieldAttr(56)] public igHandleMetaField _splineEntity = new();
        [FieldAttr(64)] public CSplineVelocityMover? _velocityMover;
        [FieldAttr(72)] public CSplineRotationMover? _rotationMover;
        [FieldAttr(80)] public CSplineAttachBehavior? _attachBehavior;
        [FieldAttr(88)] public float _previewDistance;
        [FieldAttr(92)] public float _startAtDistance;
        [FieldAttr(96)] public bool _startReversed;
        [FieldAttr(100)] public ESplineEndBehavior _endBehavior;
        [FieldAttr(104)] public bool _respondToEvents = true;
        [FieldAttr(105)] public bool _replicateDistance;
        [FieldAttr(112)] public COnSplineCompleteEventList? _onSplineCompleteEventList;
        [FieldAttr(120)] public igVscDelegateMetaField _scriptSplineCompleteCallback = new();
        [FieldAttr(136)] public bool _isPaused;
        [FieldAttr(140)] public igVec3fMetaField _previousDestinationPosition = new();
        [FieldAttr(160)] public igQuaternionfMetaField _previousDestinationRotation = new();
        [FieldAttr(176)] public igQuaternionfMetaField _startRotation = new();
        [FieldAttr(192)] public float _distance;
        [FieldAttr(196)] public bool _reversed;
        [FieldAttr(200)] public igSplineEventList? _currentEvents;
        [FieldAttr(208)] public float _velocityChangeStartValue;
        [FieldAttr(212)] public float _velocityChangeEndValue;
        [FieldAttr(216)] public float _velocityChangeDuration;
        [FieldAttr(220)] public float _velocityChangeTime;
        [FieldAttr(224)] public bool _controllerHasAttachedVehicle;
        [FieldAttr(232)] public CChangeRequest? _disableDistanceReplicationRequest;
        [FieldAttr(240)] public bool _magicMomentDisabled;
        [FieldAttr(248)] public CPhysicsMotionProperties? _cachedMotionProperties;
        [FieldAttr(256)] public bool _playPending;
        [FieldAttr(257)] public bool _playInReversePending;
        [FieldAttr(258)] public bool _pausePending;
        [FieldAttr(259)] public bool _jumpToBeginningPending;
        [FieldAttr(260)] public bool _jumpToEndPending;
        [FieldAttr(264)] public float _lastUpdateDistance;
        [FieldAttr(272)] public igHandleMetaField _disabledVehicleSplineMover = new();
    }
}
