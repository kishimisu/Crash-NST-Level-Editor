namespace Alchemy
{
    [ObjectAttr(280, 8)]
    public class CGuiBehaviorDialogBox : CGuiBehaviorDialogBoxOption
    {
        [FieldAttr(176, false)] public igGuiPlaceable? _option1placeable;
        [FieldAttr(184, false)] public igGuiPlaceable? _option2placeable;
        [FieldAttr(192, false)] public igGuiPlaceable? _bodyText;
        [FieldAttr(200, false)] public igGuiPlaceable? _titleText;
        [FieldAttr(208, false)] public igGuiPlaceable? _imagePlaceable;
        [FieldAttr(216, false)] public igGuiAnimationTag? _introAnimation;
        [FieldAttr(224, false)] public igGuiAnimationTag? _outroAnimation;
        [FieldAttr(232, false)] public igGuiAnimationTag? _idleAnimation;
        [FieldAttr(240, false)] public igGuiAnimationTag? _noButtonSetupAnimation;
        [FieldAttr(248)] public EigGuiAnimationLoopMode _animIdleLoopMode = EigGuiAnimationLoopMode.kGuiLoopRepeat;
        [FieldAttr(256)] public CChangeRequestList? _changeRequests;
        [FieldAttr(264)] public CScopedScheduledFunction? _delayInputFunction;
        [FieldAttr(272)] public igGuiAnimationCategory? _animationCategory;
    }
}
