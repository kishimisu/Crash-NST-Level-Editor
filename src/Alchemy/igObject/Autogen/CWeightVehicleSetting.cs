namespace Alchemy
{
    [ObjectAttr(48, 4)]
    public class CWeightVehicleSetting : CBaseVehicleSetting
    {
        [FieldAttr(24)] public float _coastingTimeFromMaxForwardSpeed = 0.3f;
        [FieldAttr(28)] public float _brakingTimeFromMaxForwardSpeed = 3.0f;
        [FieldAttr(32)] public float _brakingTimeFromMaxForwardSpeedArenaMode = 1.0f;
        [FieldAttr(36)] public float _airCoastingTimeFromMaxForwardSpeed = 15.0f;
        [FieldAttr(40)] public float _mass = 1000.0f;
    }
}
