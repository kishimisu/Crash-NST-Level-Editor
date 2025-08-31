namespace Alchemy
{
    [ObjectAttr(2672, 8)]
    public class CAirVehicleControllerComponentData : CBaseAirControllerComponentData
    {
        [FieldAttr(2288)] public float _hardStickThreshold = 0.89999998f;
        [FieldAttr(2292)] public float _yawMaxAngle = 50.0f;
        [FieldAttr(2296)] public float _yawMinAngle = 20.0f;
        [FieldAttr(2300)] public igVfxRangedCurveMetaField _yawTurningSpeedCurve = new();
        [FieldAttr(2384)] public igVfxRangedCurveMetaField _pitchToYawTurnAngleReduction = new();
        [FieldAttr(2468)] public float _pitchMaxAngle = 60.0f;
        [FieldAttr(2472)] public float _pitchMinAngle = 30.0f;
        [FieldAttr(2476)] public float _pitchLockedThreshold = 5.0f;
        [FieldAttr(2480)] public igVfxRangedCurveMetaField _pitchTurningSpeedCurve = new();
        [FieldAttr(2564)] public float _pitchDeadZone = 10.0f;
        [FieldAttr(2568)] public float _pitchDampingFactor = 10.0f;
        [FieldAttr(2572)] public bool _pitchAutoCenter = true;
        [FieldAttr(2576)] public float _rollAngleSlowSpeed = 60.0f;
        [FieldAttr(2580)] public float _rollAngleFastSpeed = 30.0f;
        [FieldAttr(2584)] public float _rollDeadZone = 0.1f;
        [FieldAttr(2588)] public float _rollDampingFactor = 10.0f;
        [FieldAttr(2592)] public float _rollDriftAngleMax = 90.0f;
        [FieldAttr(2596)] public float _driftAccelerationTurnSpeedScale = 0.2f;
        [FieldAttr(2600)] public float _driftCoastingTurnSpeedScale = 1.0f;
        [FieldAttr(2604)] public bool _useVehicleForward;
        [FieldAttr(2608)] public float _reticleLockDistance = 0.2f;
        [FieldAttr(2612)] public float _reticleDropDistance = 0.64999998f;
        [FieldAttr(2616)] public float _reticleLockMinSpeed = 0.015f;
        [FieldAttr(2620)] public float _reticleTravelSpeed = 1.0f;
        [FieldAttr(2624)] public float _reticleMaxTravelSpeed = 1.875f;
        [FieldAttr(2628)] public float _reticleDeadzoneSpeed = 1.0f;
        [FieldAttr(2632)] public float _horizontalScreenEdgeOffsetSlowSpeed = 0.44999999f;
        [FieldAttr(2636)] public float _verticalScreenEdgeOffsetSlowSpeed = 0.3f;
        [FieldAttr(2640)] public float _horizontalScreenEdgeOffsetFastSpeed = 0.1f;
        [FieldAttr(2644)] public float _verticalScreenEdgeOffsetFastSpeed = 0.1f;
        [FieldAttr(2648)] public float _reticleDistanceInFront = 16000.0f;
        [FieldAttr(2652)] public bool _reticleMovementIsRawInput = true;
        [FieldAttr(2656)] public float _maxTargetingDistance = 15000.0f;
        [FieldAttr(2660)] public float _targetSearchPadding = 70.0f;
        [FieldAttr(2664)] public float _linSideDragDampingFactor = 0.4f;
    }
}
