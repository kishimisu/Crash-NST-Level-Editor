namespace Alchemy
{
    [ObjectAttr(232, 8)]
    public class CGuiBehaviorBaseGraphicsMenuOption : CGuiBehavior
    {
        [FieldAttr(144)] public EGraphicsMenuSettingType _settingType;
        [FieldAttr(152, false)] public igGuiAnimationTag? _animToggle;
        [FieldAttr(160, false)] public igGuiAnimationTag? _animFailToggle;
        [FieldAttr(168, false)] public igGuiPlaceable? _labelTextPlaceable;
        [FieldAttr(176, false)] public igGuiPlaceable? _optionTextPlaceable;
        [FieldAttr(184)] public CGuiBehaviorBaseMenuOption.EMenuOptionToggleDirection _toggleDirection = CGuiBehaviorBaseMenuOption.EMenuOptionToggleDirection.MOTD_Horizontal;
        [FieldAttr(188)] public bool _toggleDirectionIndependent = true;
        [FieldAttr(189)] public bool _selectToggleEnabled = true;
        [FieldAttr(192, false)] public igGuiPlaceable? _decrementPlaceable;
        [FieldAttr(200, false)] public igGuiPlaceable? _incrementPlaceable;
        [FieldAttr(208, false)] public igGuiPlaceable? _focusPlaceable;
        [FieldAttr(216)] public EGuiMenuSound _toggleSound = EGuiMenuSound.eGMS_Confirm;
        [FieldAttr(220)] public EGuiMenuSound _toggleFailSound;
        [FieldAttr(224)] public igGuiAnimationCategory? _toggleCategory;
    }
}
