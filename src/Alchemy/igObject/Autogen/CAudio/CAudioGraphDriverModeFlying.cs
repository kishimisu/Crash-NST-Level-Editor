namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CAudioGraphDriverModeFlying : CAudioGraphDriverMode
    {
        [FieldAttr(56)] public float _defaultEngineValue = 0.5f;
        [FieldAttr(60)] public float _maxEngineValueChangePerSecond = 1.0f;
        [FieldAttr(64)] public float _maxBrakingEngineValueChangePerSecond = 2.0f;
        [FieldAttr(68)] public float _maxYawFactor = -0.2f;
        [FieldAttr(72)] public float _maxPitchFactor = 0.25f;
        [FieldAttr(76)] public float _brakeFactor = -0.5f;
        [FieldAttr(80)] public float _speedUpFactor = 0.3f;
        [FieldAttr(84)] public float _currentEngineValue;
    }
}
