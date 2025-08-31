namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igMouseInputDevice : igBaseInputDevice
    {
        [FieldAttr(40)] public bool _mouseInClientArea;
        [FieldAttr(41)] public bool _firesEvents;
        [FieldAttr(48)] public igMouseInputEventHandler? _capture;
        [FieldAttr(56)] public igVec2fMetaField _previousPosition = new();
        [FieldAttr(64)] public igVec2fMetaField _aimSensitivity = new();
        [FieldAttr(72)] public bool _cursorLocked;
    }
}
