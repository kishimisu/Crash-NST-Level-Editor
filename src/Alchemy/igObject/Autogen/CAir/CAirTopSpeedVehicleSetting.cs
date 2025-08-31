namespace Alchemy
{
    [ObjectAttr(80, 4)]
    public class CAirTopSpeedVehicleSetting : CTopSpeedVehicleSetting
    {
        [FieldAttr(48)] public float _airBrakingSpeedScale = 0.1f;
        [FieldAttr(52)] public float _airBrakingSpeedScaleOverride = 0.1f;
        [FieldAttr(56)] public float _cameraFOVMax = 115.0f;
        [FieldAttr(60)] public float _cameraFOVMin = 100.0f;
        [FieldAttr(64)] public float _arenaModeForwardSpeedScale_1 = 0.66f;
        [FieldAttr(68)] public float _stickOnlyMaxForwardSpeedDualSpeedLinearMode_1 = 1000.0f;
        [FieldAttr(72)] public float _stickOnlyMaxForwardSpeedDualSpeedMode_1 = 1000.0f;
    }
}
