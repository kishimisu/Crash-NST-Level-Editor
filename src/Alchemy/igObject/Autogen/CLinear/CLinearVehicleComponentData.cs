namespace Alchemy
{
    [ObjectAttr(552, 8)]
    public class CLinearVehicleComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public bool _controlVehicleMovement = true;
        [FieldAttr(28)] public igVec2fMetaField _translationAcceleration = new();
        [FieldAttr(36)] public igVec2fMetaField _translationDeceleration = new();
        [FieldAttr(44)] public igVec2fMetaField _translationSpeedMax = new();
        [FieldAttr(52)] public float _speedBoostAcceleration = 9000.0f;
        [FieldAttr(56)] public float _speedBoostDeceleration = 4000.0f;
        [FieldAttr(60)] public float _speedBrakeAcceleration = 8000.0f;
        [FieldAttr(64)] public float _speedBrakeDeceleration = 4000.0f;
        [FieldAttr(68)] public float _boostHandlingModifier = 1.29999995f;
        [FieldAttr(72)] public float _brakeHandlingModifier = 0.4f;
        [FieldAttr(76)] public float _boostTimeMax = 1.2f;
        [FieldAttr(80)] public float _boostCooldownTime = 2.0f;
        [FieldAttr(84)] public float _boostDistanceMax;
        [FieldAttr(88)] public float _brakeDistanceMax;
        [FieldAttr(92)] public float _boostVelocityMax = 12000.0f;
        [FieldAttr(96)] public float _brakeVelocityDecreaseMax = 2000.0f;
        [FieldAttr(100)] public EXBUTTON _boostButton = EXBUTTON.R2;
        [FieldAttr(104)] public EXBUTTON _brakeButton = EXBUTTON.L2;
        [FieldAttr(108)] public igVec3fMetaField _rotationAnglesMax = new();
        [FieldAttr(120)] public EigEaseType _rotationAtTranslationMaxEaseType;
        [FieldAttr(124)] public float _rotationDampingFactor = 0.3f;
        [FieldAttr(128)] public bool _doTargeting = true;
        [FieldAttr(136)] public CQueryFilter? _filterTargets;
        [FieldAttr(144)] public float _targetingDistance = 2000.0f;
        [FieldAttr(148)] public float _primaryReticleScale = 1.0f;
        [FieldAttr(152)] public float _targetingVerticleOffset;
        [FieldAttr(156)] public float _maxTargetingAcquireDistance = 2.0f;
        [FieldAttr(160)] public float _targetingAcquireRadius = 50.0f;
        [FieldAttr(164)] public float _targetingDropDistance = 200.0f;
        [FieldAttr(168)] public float _targetingClampPadding = 10.0f;
        [FieldAttr(172)] public float _targetingMaxSeparationDepth = 2000.0f;
        [FieldAttr(176)] public float _targetingMinKeepTargetDepth = 1000.0f;
        [FieldAttr(184)] public igHandleMetaField _primaryReticleEffectNoTarget = new();
        [FieldAttr(192)] public igHandleMetaField _primaryReticleEffectWithTarget = new();
        [FieldAttr(200)] public igHandleMetaField _lockedReticleEffect = new();
        [FieldAttr(208)] public CBoltPoint? _lockedReticleBolt;
        [FieldAttr(216)] public bool _targetingSquareStickInput = true;
        [FieldAttr(220)] public float _targetLocalVersusSreenSpaceWeight;
        [FieldAttr(224)] public bool _landTargetingHorizontalUsePositionNotAngle;
        [FieldAttr(228)] public float _landTargetingYawMax = 40.0f;
        [FieldAttr(232)] public float _landTargetingTimeToYawMax = 0.3f;
        [FieldAttr(236)] public float _landTargetingTimeToYawZero = 0.5f;
        [FieldAttr(240)] public igVfxRangedCurveMetaField _landTargetingYawAccelCurve = new();
        [FieldAttr(324)] public bool _landTargetingVerticalUsePositionNotAngle;
        [FieldAttr(325)] public bool _landTargetingVerticalAutoFall;
        [FieldAttr(328)] public float _landTargetingPitchMax = 40.0f;
        [FieldAttr(332)] public float _landTargetingPitchUpTime = 0.5f;
        [FieldAttr(336)] public float _landTargetingPitchDownTime = 0.5f;
        [FieldAttr(340)] public bool _landTargetingUseVerticalScreenSpace;
        [FieldAttr(344)] public float _landTargetingVerticalSpeed = 100.0f;
        [FieldAttr(348)] public float _landTargetingVerticalAccelTime;
        [FieldAttr(352)] public float _landTargetingVerticalMaxDistanceBelow;
        [FieldAttr(356)] public float _landTargetingVerticalMarginFromTop;
        [FieldAttr(360)] public float _landTargetingVerticalFallBackDownTime;
        [FieldAttr(364)] public float _landTargetingVerticalFallBackDownAmount;
        [FieldAttr(368)] public igVfxRangedCurveMetaField _landTargetingVerticalFallBackDownScaleCurve = new();
        [FieldAttr(452)] public float _landTargetingVerticalFallBackUpTime;
        [FieldAttr(456)] public float _landTargetingVerticalFallBackUpAmount;
        [FieldAttr(460)] public igVfxRangedCurveMetaField _landTargetingVerticalFallBackUpScaleCurve = new();
        [FieldAttr(544)] public float _initialRotationCorrectionTime = 0.5f;
    }
}
