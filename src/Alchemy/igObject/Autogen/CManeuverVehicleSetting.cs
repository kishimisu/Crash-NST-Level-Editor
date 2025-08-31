namespace Alchemy
{
    [ObjectAttr(80, 4)]
    public class CManeuverVehicleSetting : CBaseVehicleSetting
    {
        [FieldAttr(24)] public float _airTurningSpeed = 48.0f;
        [FieldAttr(28)] public float _arenaModeAirTurningSpeedScale = 5.0f;
        [FieldAttr(32)] public float _turningSpeedFactorForRelativeControls = 1.0f;
        [FieldAttr(36)] public float _surfaceTurningSpeed = 96.0f;
        [FieldAttr(40)] public float _surfaceTurningSpeedWhileBoostingScale = 1.0f;
        [FieldAttr(44)] public float _arenaModeSurfaceTurningSpeedScale = 1.25f;
        [FieldAttr(48)] public float _arenaModeSurfaceTurningSpeedScaleWhileReversing = 1.0f;
        [FieldAttr(52)] public float _accelerationTimeToMaxTurningSpeed = 0.2f;
        [FieldAttr(56)] public float _accelerationTimeToMaxTurningSpeedArena = 0.69999999f;
        [FieldAttr(60)] public float _coastingTimeFromMaxTurningSpeed = 0.1f;
        [FieldAttr(64)] public float _brakingTimeFromMaxTurningSpeed = 0.1f;
        [FieldAttr(68)] public float _maxLinearModeTurningPushSurface = 2500.0f;
        [FieldAttr(72)] public float _maxLinearModeTurningPushAir = 2500.0f;
        [FieldAttr(76)] public float _rollTurnRate = 130.0f;
    }
}
