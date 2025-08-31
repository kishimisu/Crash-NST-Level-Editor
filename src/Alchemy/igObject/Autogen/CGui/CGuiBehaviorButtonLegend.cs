namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CGuiBehaviorButtonLegend : igGuiBehavior
    {
        [FieldAttr(16, false)] public igGuiAnimationTag? _buttonLegendScaleAnimation;
        [FieldAttr(24, false)] public igGuiPlaceable? _buttonLegendListPlaceable;
        [FieldAttr(32, false)] public igGuiPlaceable? _buttonLegendPlaceable;
        [FieldAttr(40, false)] public igGuiPlaceable? _buttonLegendTextPlaceable;
        [FieldAttr(48)] public bool _forceListDisplay;
        [FieldAttr(49)] public bool _isVertical;
        [FieldAttr(56)] public CGuiButtonLegendTable? _workingButtonLegendData;
        [FieldAttr(64)] public CGuiButtonLegendTable? _buttonLegendTable;
        [FieldAttr(72)] public string? _currentButtonLegend = null;
        [FieldAttr(80)] public bool _buttonLegendHasChanged = true;
        [FieldAttr(81)] public bool _buttonLegendVisible = true;
        [FieldAttr(82)] public bool _buttonLegendDirty;
        [FieldAttr(84)] public CController.EInputDeviceType _buttonLegendDeviceType;
    }
}
