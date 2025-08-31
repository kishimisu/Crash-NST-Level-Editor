namespace Alchemy
{
    [ObjectAttr(256, 8)]
    public class CGuiBehaviorNavigationItem : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiAnimationTag? _animFocusOn;
        [FieldAttr(152, false)] public igGuiAnimationTag? _animFocusOff;
        [FieldAttr(160, false)] public igGuiAnimationTag? _animFocusedLoop;
        [FieldAttr(168)] public EigGuiAnimationLoopMode _animFocusedLoopMode = EigGuiAnimationLoopMode.kGuiLoopRepeat;
        [FieldAttr(176, false)] public igGuiAnimationTag? _animFocusabilityOn;
        [FieldAttr(184, false)] public igGuiAnimationTag? _animFocusabilityOff;
        [FieldAttr(192)] public string? _itemText = null;
        [FieldAttr(200, false)] public igGuiPlaceable? _textPlaceable;
        [FieldAttr(208, false)] public igGuiPlaceable? _leftItem;
        [FieldAttr(216, false)] public igGuiPlaceable? _rightItem;
        [FieldAttr(224, false)] public igGuiPlaceable? _upItem;
        [FieldAttr(232, false)] public igGuiPlaceable? _downItem;
        [FieldAttr(240)] public EGuiMenuSound _focusSound = EGuiMenuSound.eGMS_Navigate;
        [FieldAttr(248)] public igGuiAnimationCategory? _focusCategory;
    }
}
