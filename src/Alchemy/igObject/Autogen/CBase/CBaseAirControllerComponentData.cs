namespace Alchemy
{
    [ObjectAttr(2288, 8)]
    public class CBaseAirControllerComponentData : CBaseVehicleControllerComponentData
    {
        [FieldAttr(1776)] public igHandleMetaField _softCollisionMaterial = new();
        [FieldAttr(1784)] public float _softCollisionRadius = 1000.0f;
        [FieldAttr(1788)] public float _softCollisionSpeedDivider = 200.0f;
        [FieldAttr(1792)] public float _softCollisionImpulse = 350.0f;
        [FieldAttr(1796)] public float _softCollisionMinForwardVel = 2000.0f;
        [FieldAttr(1800)] public float _softCollisionForwardImpulse = 200.0f;
        [FieldAttr(1804)] public float _softCollisionStopTurnAngle = 30.0f;
        [FieldAttr(1808)] public igHandleMetaField _softCollisionVfxToSpawn = new();
        [FieldAttr(1816)] public float _softCollisionVfxSpawnOffset = 200.0f;
        [FieldAttr(1820)] public float _speedIntensityDampingFactor = 0.5f;
        [FieldAttr(1824)] public igVfxRangedCurveMetaField _accelerationToMaxSpeedIntensityCurve = new();
        [FieldAttr(1908)] public igVfxRangedCurveMetaField _decelerationToCoastingSpeedIntensityCurve = new();
        [FieldAttr(1992)] public igVfxRangedCurveMetaField _accelerationToCoastingSpeedIntensityCurve = new();
        [FieldAttr(2076)] public igVfxRangedCurveMetaField _decelerationToBrakingSpeedIntensityCurve = new();
        [FieldAttr(2160)] public float _softCollisionBoostImpulseMultiplier = 8.0f;
        [FieldAttr(2164)] public float _softCollisionBoostForwardImpulseMultiplier = 2.0f;
        [FieldAttr(2168)] public float _softCollisionBoostTurnMultiplier = 2.0f;
        [FieldAttr(2172)] public bool _useBrakingSpeedScaleOverride;
        [FieldAttr(2176)] public float _barrelRollPushForce = 3500.0f;
        [FieldAttr(2180)] public float _barrelRollTime = 1.0f;
        [FieldAttr(2184)] public float _barrelRollCooldownTime = 0.1f;
        [FieldAttr(2188)] public igVfxRangedCurveMetaField _barrelRollPushCurve = new();
        [FieldAttr(2272)] public float _inputAxisLockout = 0.89999998f;
        [FieldAttr(2276)] public float _inputAxisReduction = 0.5f;
        [FieldAttr(2280)] public bool _showReticle = true;
        [FieldAttr(2281)] public bool _reticleDrivesInput;
        [FieldAttr(2282)] public bool _useAnalogSteeringFix = true;
        [FieldAttr(2284)] public EXBUTTON _jumpButtonSecondary = EXBUTTON.JUMP;
    }
}
