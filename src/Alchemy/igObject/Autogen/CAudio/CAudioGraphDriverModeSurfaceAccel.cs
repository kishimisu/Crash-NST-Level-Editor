namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class CAudioGraphDriverModeSurfaceAccel : CAudioGraphDriverMode
    {
        [FieldAttr(56)] public CAudioGraphDriverModeSurfaceAccelStageList? _accelStages;
        [FieldAttr(64)] public float _topSpeedGraphInput = 1.0f;
        [FieldAttr(68)] public float _slopeAccelTimeStretch = -0.4f;
        [FieldAttr(72)] public float _turnAccelTimeStretch = -0.4f;
        [FieldAttr(76)] public float _slopeTopSpeedChange = -0.2f;
        [FieldAttr(80)] public float _turnTopSpeedChange = -0.2f;
        [FieldAttr(84)] public float _startInputMax = 1.0f;
        [FieldAttr(88)] public float _maxIntroGraphInputChangePerSecond = 2.0f;
        [FieldAttr(92)] public bool _loopFinalAccelStage;
        [FieldAttr(96)] public float _inactiveMemoryTime = 1.0f;
        [FieldAttr(100)] public float _introCurrentInput;
        [FieldAttr(104)] public float _introTargetInput;
        [FieldAttr(108)] public bool _introActive;
        [FieldAttr(112)] public igTimeMetaField _currentTime = new();
        [FieldAttr(120, false)] public CAudioGraphDriverModeSurfaceAccelStage? _lastStage;
        [FieldAttr(128)] public CTimer? _inactiveTimer;
        [FieldAttr(136)] public igTimeMetaField _memoryTime = new();
        [FieldAttr(140)] public bool _resetOnNextActivation;
    }
}
