namespace Alchemy
{
    [ObjectAttr(144, 8)]
    public class CKeyboardInputListener : CInputListener
    {
        [FieldAttr(136)] public igKeyboardInputDevice.ESignal _key;
        [FieldAttr(140)] public bool _requireShift;
    }
}
