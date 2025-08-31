namespace Alchemy
{
    [ObjectAttr(232, 4)]
    public class CLinearDriftVehicleSetting : CDriftVehicleSetting
    {
        [FieldAttr(48)] public igVfxRangedCurveMetaField _angularSpeedMultiplierOverTimeCurve = new();
        [FieldAttr(132)] public igVfxRangedCurveMetaField _angularSpeedAdderOverTimeCurve = new();
        [FieldAttr(216)] public float _driftTimeToModifierCurvesEnd = 5.0f;
        [FieldAttr(220)] public float _maxAngularSpeed = 50.0f;
        [FieldAttr(224)] public float _counterSteerMultiplier = 0.1f;
        [FieldAttr(228)] public float _driftTimeToMaxTurn;
    }
}
