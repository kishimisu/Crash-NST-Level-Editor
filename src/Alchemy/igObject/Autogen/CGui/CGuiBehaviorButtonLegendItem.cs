namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CGuiBehaviorButtonLegendItem : igGuiBehavior
    {
        [FieldAttr(16, false)] public igGuiAnimationTag? _buttonScaleAnimation;
        [FieldAttr(24, false)] public igGuiAnimationTag? _buttonSelectAnimation;
        [FieldAttr(32, false)] public igGuiAnimationTag? _mobileOnAnimation;
        [FieldAttr(40, false)] public igGuiAnimationTag? _mobileOffAnimation;
        [FieldAttr(48, false)] public igGuiPlaceable? _buttonTextPlaceable;
        [FieldAttr(56, false)] public igGuiPlaceable? _touchButtonTextPlaceable;
        [FieldAttr(64, false)] public igGuiPlaceable? _touchablePlaceable;
        [FieldAttr(72)] public igGuiInput.ESignal _button;
        [FieldAttr(76)] public igGuiInput.EController _touchControl;
    }
}
