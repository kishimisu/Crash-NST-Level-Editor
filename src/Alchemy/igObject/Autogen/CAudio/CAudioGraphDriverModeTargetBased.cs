namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CAudioGraphDriverModeTargetBased : CAudioGraphDriverMode
    {
        [FieldAttr(56)] public float _targetGraphInput = 0.89999998f;
        [FieldAttr(60)] public float _graphInputChangePerSecond = 2.0f;
        [FieldAttr(64)] public float _currentGraphInput;
    }
}
