namespace Alchemy
{
    [ObjectAttr(184, 8)]
    public class CGuiBehaviorResetOptionsToDefaults : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiAnimationTag? _animPress;
        [FieldAttr(152, false)] public igGuiPlaceable? _textPlaceable;
        [FieldAttr(160)] public string? _displayText = null;
        [FieldAttr(168)] public EGuiMenuSound _pressSound = EGuiMenuSound.eGMS_Confirm;
        [FieldAttr(176)] public CGameVariableHandleList? _gameVariables;
    }
}
