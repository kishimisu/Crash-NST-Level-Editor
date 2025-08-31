namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class ActorInput : igObject
    {
        [FieldAttr(16)] public ActorInputCommand? _input;
        [FieldAttr(24)] public float _delta;
        [FieldAttr(28)] public float _deltaScaled;
        [FieldAttr(32)] public i64 _previousButtonStates;
        [FieldAttr(40)] public CTimer? _touchDuration;
        [FieldAttr(48)] public igVec3fMetaField _lastPressedDirection = new();
        [FieldAttr(60)] public float _stickSpeedWithDeadzone;
        [FieldAttr(64)] public bool _inputProcessed;
        [FieldAttr(72)] public COnProcessInputEventList? _onProcessInputEventList;
        [FieldAttr(80)] public COnProcessInputDelegate? _onProcessInput;
        [FieldAttr(88)] public CEnableRequestManager? _lockControls;
    }
}
