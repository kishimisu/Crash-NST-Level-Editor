namespace Alchemy
{
    [ObjectAttr(208, 8)]
    public class CGuiBehaviorKeyboardMenu : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiPlaceable? _textPressKeyPrompt;
        [FieldAttr(152, false)] public igGuiList? _optionsList;
        [FieldAttr(160, false)] public igGuiAnimationTag? _crash1Animation;
        [FieldAttr(168, false)] public igGuiAnimationTag? _crash2Animation;
        [FieldAttr(176, false)] public igGuiAnimationTag? _crash3Animation;
        [FieldAttr(184)] public string? _option1Text = null;
        [FieldAttr(192)] public string? _option2Text = null;
        [FieldAttr(200)] public string? _backText = null;
    }
}
