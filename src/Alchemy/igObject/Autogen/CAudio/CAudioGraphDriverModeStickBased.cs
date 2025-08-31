namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CAudioGraphDriverModeStickBased : CAudioGraphDriverMode
    {
        [FieldAttr(56)] public float _fullStickGraphInput = 0.89999998f;
        [FieldAttr(60)] public float _noStickGraphInput;
        [FieldAttr(64)] public float _graphInputChangePerSecond = 2.0f;
        [FieldAttr(68)] public float _targetGraphInput;
        [FieldAttr(72)] public float _currentGraphInput;
    }
}
