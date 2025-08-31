namespace Alchemy
{
    [ObjectAttr(336, 8)]
    public class CCommonVehicleBehaviorComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public bool _autoDetermineDriveState;
        [FieldAttr(25)] public bool _autoDetermineAccelerateState = true;
        [FieldAttr(26)] public bool _autoDriveIgnoreZVelocity;
        [FieldAttr(28)] public float _autoDriveIdleSpeed = 100.0f;
        [FieldAttr(32)] public float _autoDriveRequiredFullSpeedRatio = 0.89999998f;
        [FieldAttr(40)] public string? _idleEvent = "Idle";
        [FieldAttr(48)] public string? _idleState = "Idle";
        [FieldAttr(56)] public string? _slowSpeedEvent = "Drive_Slow";
        [FieldAttr(64)] public string? _slowSpeedState = "Drive_Slow";
        [FieldAttr(72)] public string? _maxSpeedEvent = "Drive_FullSpeed";
        [FieldAttr(80)] public string? _maxSpeedState = "Drive_FullSpeed";
        [FieldAttr(88)] public string? _reverseEvent = "Drive_Reverse";
        [FieldAttr(96)] public string? _reverseState = "Drive_Reverse";
        [FieldAttr(104)] public string? _brakeBeginEvent = "BrakingFadeIn";
        [FieldAttr(112)] public string? _brakeEndEvent = "BrakingFadeOut";
        [FieldAttr(120)] public string? _brakeState = "Braking";
        [FieldAttr(128)] public string? _brakeStopBeginEvent = "Brake_Stop";
        [FieldAttr(136)] public string? _brakeStopState = "Brake_Stop";
        [FieldAttr(144)] public string? _accelerateBeginEvent = "AccelerateFadeIn";
        [FieldAttr(152)] public string? _accelerateEndEvent = "AccelerateFadeOut";
        [FieldAttr(160)] public string? _accelerateState = "Accelerate";
        [FieldAttr(168)] public string? _diveEvent = "Dive";
        [FieldAttr(176)] public string? _diveState = "Submerge";
        [FieldAttr(184)] public string? _jumpEvent = "Jump";
        [FieldAttr(192)] public string? _halfPipeJumpEvent = "Jump";
        [FieldAttr(200)] public string? _halfPipeFallEvent = "Fall";
        [FieldAttr(208)] public string? _jumpState = "Jump";
        [FieldAttr(216)] public string? _fallEvent = "Fall";
        [FieldAttr(224)] public string? _fallState = "Falling";
        [FieldAttr(232)] public string? _landEvent = "Land";
        [FieldAttr(240)] public string? _deathState = "Death";
        [FieldAttr(248)] public string? _outroState = "Outro";
        [FieldAttr(256)] public string? _driftBeginEvent = "DriftFadeIn";
        [FieldAttr(264)] public string? _driftEndEvent = "DriftFadeOut";
        [FieldAttr(272)] public string? _driftState = "Drift";
        [FieldAttr(280)] public string? _boostBeginEvent = "Boost_Beginning";
        [FieldAttr(288)] public float _brakeRequiredSpeedRatio = 0.1f;
        [FieldAttr(292)] public float _brakeStopSpeedRatio = 0.1f;
        [FieldAttr(296)] public float _reverseRequiredSpeedRatio = 0.1f;
        [FieldAttr(304)] public igHandleMetaField _velocityTriggeredVfx = new();
        [FieldAttr(312)] public float _velocityToTriggervfx = 2000.0f;
        [FieldAttr(316)] public float _minLandHardVelocity = 2000.0f;
        [FieldAttr(320)] public bool _updateTurningBlend = true;
        [FieldAttr(324)] public float _turningBlendChangePerSecond = -1.0f;
        [FieldAttr(328)] public bool _flipTurnWhenDrifting;
    }
}
