namespace Alchemy
{
    [ObjectAttr(160, 8)]
    public class CSplineLaneMoverComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public igHandleMetaField _splineEntity = new();
        [FieldAttr(32)] public igHandleMetaField _splineStart = new();
        [FieldAttr(40)] public igHandleMetaField _splineEnd = new();
        [FieldAttr(48)] public bool _teleportToStartOnEnable;
        [FieldAttr(49)] public bool _startOnEnable;
        [FieldAttr(52)] public ESplineLaneMoverForwardMovementType _forwardMovementType;
        [FieldAttr(56)] public float _forwardVelocity = 1000.0f;
        [FieldAttr(60)] public bool _useTimeBasedVelocity;
        [FieldAttr(64)] public float _timeToCompleteSpline = 1.0f;
        [FieldAttr(68)] public float _easeVelocityFactor = 0.89999998f;
        [FieldAttr(72)] public EigEaseType _easeInType = EigEaseType.kEaseTypeQuadratic;
        [FieldAttr(76)] public float _easeInFraction;
        [FieldAttr(80)] public EigEaseType _easeOutType = EigEaseType.kEaseTypeQuadratic;
        [FieldAttr(84)] public float _easeOutFraction;
        [FieldAttr(88)] public bool _startReversed;
        [FieldAttr(89)] public bool _ignoreVelocityKeyframes = true;
        [FieldAttr(92)] public ESplineLaneMoverHorizontalMovementType _horizontalMovementType;
        [FieldAttr(96)] public float _horizontalVelocity = 1000.0f;
        [FieldAttr(100)] public float _horizontalAcceleration = 1000.0f;
        [FieldAttr(104)] public float _horizontalConvergence = 1.0f;
        [FieldAttr(108)] public float _spacingFromLaneEdges;
        [FieldAttr(112)] public float _splineTurnInfluence;
        [FieldAttr(116)] public ESplineLaneMoverVerticalMovementType _verticalMovementType;
        [FieldAttr(120)] public float _slopeCompensation;
        [FieldAttr(124)] public bool _verticalMovementWhileStopped;
        [FieldAttr(128)] public ESplineLaneMoverOrientationType _orientationType = ESplineLaneMoverOrientationType.eSLMO_FaceAlongSpline;
        [FieldAttr(132)] public ESplineLaneMoverUpOrientation _upOrientation;
        [FieldAttr(136)] public float _orientationTime = 0.2f;
        [FieldAttr(140)] public float _splineTurnExaggeration = 1.0f;
        [FieldAttr(144)] public float _turnFadeOuterEdge = 100.0f;
        [FieldAttr(148)] public float _turnFadeOuterFactor = 1.0f;
        [FieldAttr(152)] public float _turnFadeInnerEdge;
        [FieldAttr(156)] public float _turnFadeInnerFactor = 1.0f;
    }
}
