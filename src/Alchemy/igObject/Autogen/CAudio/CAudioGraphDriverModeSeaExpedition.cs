namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CAudioGraphDriverModeSeaExpedition : CAudioGraphDriverMode
    {
        [FieldAttr(56)] public float _defaultEngineValue = 0.2f;
        [FieldAttr(60)] public float _ascendingEngineValue = 0.8f;
        [FieldAttr(64)] public float _maxEngineValueChangePerSecond = 1.0f;
        [FieldAttr(68)] public float _currentEngineValue;
    }
}
