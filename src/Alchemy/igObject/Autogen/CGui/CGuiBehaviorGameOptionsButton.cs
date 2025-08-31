namespace Alchemy
{
    [ObjectAttr(176, 8)]
    public class CGuiBehaviorGameOptionsButton : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiAnimationTag? _pressAnimation;
        [FieldAttr(152)] public EGuiMenuSound _pressSound = EGuiMenuSound.eGMS_Confirm;
        [FieldAttr(160)] public string? _defaultText = "OPTIONS";
        [FieldAttr(168, false)] public igGuiProject? _optionsProject;
    }
}
