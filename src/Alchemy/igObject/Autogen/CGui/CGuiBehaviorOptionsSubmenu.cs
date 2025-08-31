namespace Alchemy
{
    [ObjectAttr(248, 8)]
    public class CGuiBehaviorOptionsSubmenu : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiPlaceable? _textGamepadControls;
        [FieldAttr(152, false)] public igGuiPlaceable? _textKeyboardControls;
        [FieldAttr(160, false)] public igGuiPlaceable? _textGraphics;
        [FieldAttr(168)] public string? _backText = null;
        [FieldAttr(176, false)] public igGuiProject? _gamepadControlsProject;
        [FieldAttr(184, false)] public igGuiProject? _keyboardControlsProject;
        [FieldAttr(192, false)] public igGuiProject? _graphicsProject;
        [FieldAttr(200)] public float _delayInputDuration;
        [FieldAttr(208, false)] public igGuiAnimationTag? _crash1Animation;
        [FieldAttr(216, false)] public igGuiAnimationTag? _crash2Animation;
        [FieldAttr(224, false)] public igGuiAnimationTag? _crash3Animation;
        [FieldAttr(232, false)] public igGuiAnimationTag? _menuIntroAnimation;
        [FieldAttr(240, false)] public igGuiAnimationTag? _menuOutroAnimation;
    }
}
