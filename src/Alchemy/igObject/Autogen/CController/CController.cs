namespace Alchemy
{
    [ObjectAttr(4312, 8)]
    public class CController : igObject
    {
        public enum EInputDeviceType : uint
        {
            IDT_GAMEPAD = 0,
            IDT_KEYBOARD = 1,
            IDT_POINTER = 2,
            IDT_VIRTUAL = 3,
            IDT_COUNT = 4,
        }

        [FieldAttr(3984, false)] public igBaseInputDevice? _inputDevice;
        [FieldAttr(3992, false)] public igKeyboardInputDevice? _keyboardDevice;
        [FieldAttr(4000, false)] public igMouseInputDevice? _mouseDevice;
        [FieldAttr(4008)] public EControllerType _controllerType;
        [FieldAttr(4016)] public u64 _buttonState;
        [FieldAttr(4024)] public u64 _previousButtonState;
        [FieldAttr(4032)] public u64 _forcedButtonState;
        [FieldAttr(4040)] public float[] _deflections = new float[62];
        [FieldAttr(4288)] public igTimeMetaField[] _motorTimeOff = new igTimeMetaField[2];
        [FieldAttr(4296)] public bool[] _motorOn = new bool[2];
        [FieldAttr(4300)] public igTimeMetaField _lastActivity = new();
        [FieldAttr(4304)] public bool _remoteDevice;
        [FieldAttr(4308)] public EInputDeviceType _activeDeviceType;
    }
}
