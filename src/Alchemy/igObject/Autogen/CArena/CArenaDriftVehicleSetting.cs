namespace Alchemy
{
    [ObjectAttr(160, 4)]
    public class CArenaDriftVehicleSetting : CDriftVehicleSetting
    {
        [FieldAttr(48)] public igVfxRangedCurveMetaField _accelerationVelocityCurve = new();
        [FieldAttr(132)] public float _accelerationTimeToMaxSpeed = 1.0f;
        [FieldAttr(136)] public float _forwardSpeedPreservedAtMinAngle = 1.0f;
        [FieldAttr(140)] public float _forwardSpeedPreservedAtMaxAngle = 0.69999999f;
        [FieldAttr(144)] public float _angleThresholdRemoveMaxSpeed = 30.0f;
        [FieldAttr(148)] public float _angleVelocityThresholdStop = 40.0f;
        [FieldAttr(152)] public float _turningSpeedScaleForRelativeControls = 1.0f;
    }
}
