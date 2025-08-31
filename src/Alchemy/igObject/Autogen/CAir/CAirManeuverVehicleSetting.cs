namespace Alchemy
{
    [ObjectAttr(184, 4)]
    public class CAirManeuverVehicleSetting : CManeuverVehicleSetting
    {
        [FieldAttr(80)] public float _pitchUpMaxTurningSpeed = 240.0f;
        [FieldAttr(84)] public float _pitchUpMinTurningSpeed = 240.0f;
        [FieldAttr(88)] public float _pitchDownMaxTurningSpeed = 240.0f;
        [FieldAttr(92)] public float _pitchDownMinTurningSpeed = 240.0f;
        [FieldAttr(96)] public float _yawMaxTurningSpeed = 240.0f;
        [FieldAttr(100)] public float _yawMinTurningSpeed = 240.0f;
        [FieldAttr(104)] public float _rollMaxTurnRate = 5.0f;
        [FieldAttr(108)] public float _rollMinTurnRate = 5.0f;
        [FieldAttr(112)] public float _airAcceleratingDriftSideDragScale = 0.005f;
        [FieldAttr(116)] public float _airCoastingDriftSideDragScale = 0.5f;
        [FieldAttr(120)] public float _pitchUpAccelerationTimeToMaxTurningSpeed = 0.2f;
        [FieldAttr(124)] public float _pitchUpCoastingTimeFromMaxTurningSpeed = 0.1f;
        [FieldAttr(128)] public float _pitchUpBrakingTimeFromMaxTurningSpeed = 0.1f;
        [FieldAttr(132)] public float _pitchDownAccelerationTimeToMaxTurningSpeed = 0.2f;
        [FieldAttr(136)] public float _pitchDownCoastingTimeFromMaxTurningSpeed = 0.1f;
        [FieldAttr(140)] public float _pitchDownBrakingTimeFromMaxTurningSpeed = 0.1f;
        [FieldAttr(144)] public float _airTurningSpeed_1 = 48.0f;
        [FieldAttr(148)] public float _arenaModeAirTurningSpeedScale_1 = 5.0f;
        [FieldAttr(152)] public float _surfaceTurningSpeed_1 = 96.0f;
        [FieldAttr(156)] public float _arenaModeSurfaceTurningSpeedScale_1 = 1.25f;
        [FieldAttr(160)] public float _accelerationTimeToMaxTurningSpeed_1 = 0.2f;
        [FieldAttr(164)] public float _coastingTimeFromMaxTurningSpeed_1 = 0.1f;
        [FieldAttr(168)] public float _brakingTimeFromMaxTurningSpeed_1 = 0.1f;
        [FieldAttr(172)] public float _maxLinearModeTurningPushSurface_1 = 2500.0f;
        [FieldAttr(176)] public float _maxLinearModeTurningPushAir_1 = 2500.0f;
    }
}
