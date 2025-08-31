namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CAccelerationVehicleSetting : CBaseVehicleSetting
    {
        [FieldAttr(24)] public float _accelerationTimeToMaxForwardSpeed = 1.0f;
        [FieldAttr(28)] public float _airAccelerationTimeToMaxForwardSpeed = 1.0f;
        [FieldAttr(32)] public float _arenaModeAccelerationTimeScale = 1.0f;
    }
}
