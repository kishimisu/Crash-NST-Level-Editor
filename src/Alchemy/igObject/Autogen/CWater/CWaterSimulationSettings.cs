namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CWaterSimulationSettings : igObject
    {
        [FieldAttr(16)] public float _accelerationScale = 10.0f;
        [FieldAttr(20)] public float _velocityScale = 60.0f;
        [FieldAttr(24)] public float _dampenScale = 1.5f;
        [FieldAttr(28)] public float _simulationUnitScale = 8.0f;
    }
}
