namespace Alchemy
{
    [ObjectAttr(256, 8)]
    public class CVehicleTransitionComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public bool _startEnabled = true;
        [FieldAttr(25)] public bool _useBasicTransitionWhenForced;
        [FieldAttr(32)] public CVehicleSection? _vehicleSection;
        [FieldAttr(40)] public igHandleMetaField _defaultGameplayCamera = new();
        [FieldAttr(48)] public float _defaultGameplayCameraBlendTime = 1.0f;
        [FieldAttr(52)] public float _reactivationDelay = -1.0f;
        [FieldAttr(56)] public EVehicleType _requiredVehicleType;
        [FieldAttr(64)] public igHandleMetaField _transitionSuccessMusicSettings = new();
        [FieldAttr(72)] public float _transitionSuccessMusicSettingsDelay;
        [FieldAttr(80)] public igHandleMetaField _afterTransitionTeleportDestination = new();
        [FieldAttr(88)] public igHandleMetaField _beforeTransitionTeleportDestination = new();
        [FieldAttr(96)] public igHandleMetaField _fadeOut = new();
        [FieldAttr(104)] public float _fadeOutDelay;
        [FieldAttr(112)] public igHandleMetaField _fadeIn = new();
        [FieldAttr(120)] public float _fadeInDelay;
        [FieldAttr(128)] public CVehicleBoostData? _afterTransitionBoost;
        [FieldAttr(136)] public bool _fireTransitionBehaviorEvent;
        [FieldAttr(137)] public bool _splineAfterTransform;
        [FieldAttr(138)] public bool _useAlternateGateAnimation;
        [FieldAttr(144)] public igHandleMetaField _extraSplineEntity = new();
        [FieldAttr(152)] public float _forwardTransformMomentum;
        [FieldAttr(156)] public float _forwardTransformMomentumAlt;
        [FieldAttr(160)] public float _extraSplineSectionChangeDelay = -1.0f;
        [FieldAttr(168)] public CBoltPoint? _vfxBolt;
        [FieldAttr(176)] public CWaypoint? _vfxSpawnPoint;
        [FieldAttr(184)] public float _vfxRadiusApproach = 1000.0f;
        [FieldAttr(192)] public igHandleMetaField _enableEffect = new();
        [FieldAttr(200)] public igHandleMetaField _loopEffect = new();
        [FieldAttr(208)] public igHandleMetaField _transitionSuccessEffect = new();
        [FieldAttr(216)] public igHandleMetaField _enableSound = new();
        [FieldAttr(224)] public igHandleMetaField _loopSound = new();
        [FieldAttr(232)] public igHandleMetaField _transitionSuccessSound = new();
        [FieldAttr(240)] public CSetGameSpeedMessage? _setGameSpeedMessage;
        [FieldAttr(248)] public float _sendGameSpeedMessageDelay;
    }
}
