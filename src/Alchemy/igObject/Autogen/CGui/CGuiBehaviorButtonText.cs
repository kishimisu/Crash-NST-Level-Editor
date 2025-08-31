namespace Alchemy
{
    [ObjectAttr(160, 8)]
    public class CGuiBehaviorButtonText : CGuiBehavior
    {
        [FieldAttr(144)] public string? _originalText = null;
        [FieldAttr(152)] public CController.EInputDeviceType _buttonDeviceType;
    }
}
