namespace Alchemy
{
    [ObjectAttr(216, 8)]
    public class CGuiBehaviorBaseMenuOption : CGuiBehavior
    {
        public enum EMenuOptionToggleDirection : uint
        {
            MOTD_None = 0,
            MOTD_Horizontal = 1,
            MOTD_Vertical = 2,
        }

        [FieldAttr(144, false)] public igGuiAnimationTag? _animToggle;
        [FieldAttr(152, false)] public igGuiAnimationTag? _animFailToggle;
        [FieldAttr(160, false)] public igGuiPlaceable? _labelTextPlaceable;
        [FieldAttr(168, false)] public igGuiPlaceable? _optionTextPlaceable;
        [FieldAttr(176)] public EMenuOptionToggleDirection _toggleDirection = CGuiBehaviorBaseMenuOption.EMenuOptionToggleDirection.MOTD_Horizontal;
        [FieldAttr(180)] public bool _toggleDirectionIndependent = true;
        [FieldAttr(181)] public bool _selectToggleEnabled = true;
        [FieldAttr(184, false)] public igGuiPlaceable? _decrementPlaceable;
        [FieldAttr(192, false)] public igGuiPlaceable? _incrementPlaceable;
        [FieldAttr(200)] public EGuiMenuSound _toggleSound = EGuiMenuSound.eGMS_Confirm;
        [FieldAttr(204)] public EGuiMenuSound _toggleFailSound;
        [FieldAttr(208)] public bool _isConfigured;
    }
}
