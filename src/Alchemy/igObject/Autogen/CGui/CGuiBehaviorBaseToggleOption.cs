namespace Alchemy
{
    [ObjectAttr(216, 8)]
    public class CGuiBehaviorBaseToggleOption : CGuiBehavior
    {
        public enum EToggleDirection : uint
        {
            eTD_None = 0,
            eTD_Horizontal = 1,
            eTD_Vertical = 2,
        }

        [FieldAttr(144, false)] public igGuiAnimationTag? _animToggle;
        [FieldAttr(152, false)] public igGuiAnimationTag? _animFailToggle;
        [FieldAttr(160, false)] public igGuiPlaceable? _textPlaceable;
        [FieldAttr(168)] public EToggleDirection _toggleDirection = CGuiBehaviorBaseToggleOption.EToggleDirection.eTD_Horizontal;
        [FieldAttr(172)] public bool _toggleDirectionIndependent = true;
        [FieldAttr(173)] public bool _selectToggleEnabled = true;
        [FieldAttr(176, false)] public igGuiPlaceable? _decrementPlaceable;
        [FieldAttr(184, false)] public igGuiPlaceable? _incrementPlaceable;
        [FieldAttr(192)] public EGuiMenuSound _toggleSound = EGuiMenuSound.eGMS_Confirm;
        [FieldAttr(196)] public EGuiMenuSound _toggleFailSound;
        [FieldAttr(200)] public igGuiAnimationCategory? _toggleCategory;
        [FieldAttr(208)] public bool _currentValue;
        [FieldAttr(209)] public bool _lastSavedValue;
    }
}
