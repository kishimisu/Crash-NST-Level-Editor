namespace Alchemy
{
    [ObjectAttr(216, 8)]
    public class CAudioGraphDriverModeSurfaceBurnout : CAudioGraphDriverModeTargetBased
    {
        [FieldAttr(72)] public float _maxSpeedRatio = 0.5f;
        [FieldAttr(76)] public float _forwardSpeedChangeThresholdLow = 50.0f;
        [FieldAttr(80)] public float _forwardSpeedChangeThresholdHigh = 200.0f;
        [FieldAttr(84)] public int _forwardSpeedHistoryCount = 5;
        [FieldAttr(88)] public float[] _forwardSpeedHistory = new float[30];
        [FieldAttr(208)] public int _historyCounter;
    }
}
