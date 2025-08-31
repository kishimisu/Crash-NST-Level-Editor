namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CDriftVehicleSetting : CBaseVehicleSetting
    {
        [FieldAttr(24)] public float _angleThresholdStart = 85.0f;
        [FieldAttr(28)] public float _angleThresholdStop = 10.0f;
        [FieldAttr(32)] public float _turningSpeedOverride = 240.0f;
        [FieldAttr(36)] public float _minimumDriftTime = 0.1f;
        [FieldAttr(40)] public float _sideDragScale = 1.0f;
    }
}
