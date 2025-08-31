namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CTopSpeedVehicleSetting : CBaseVehicleSetting
    {
        [FieldAttr(24)] public float _maxForwardSpeed = 3600.0f;
        [FieldAttr(28)] public float _maxReverseSpeed = -2500.0f;
        [FieldAttr(32)] public float _arenaModeForwardSpeedScale = 0.66f;
        [FieldAttr(36)] public float _stickOnlyMaxForwardSpeedDualSpeedLinearMode = 1000.0f;
        [FieldAttr(40)] public float _stickOnlyMaxForwardSpeedDualSpeedMode = 1000.0f;
        [FieldAttr(44)] public float _coastingSpeedScale = 0.5f;
    }
}
