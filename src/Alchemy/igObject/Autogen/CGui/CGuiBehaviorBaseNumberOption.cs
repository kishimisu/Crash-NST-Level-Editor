namespace Alchemy
{
    [ObjectAttr(240, 8)]
    public class CGuiBehaviorBaseNumberOption : CGuiBehavior
    {
        public enum EIncrementDirection : uint
        {
            eID_Horizontal = 0,
            eID_Vertical = 1,
        }

        [FieldAttr(144, false)] public igGuiAnimationTag? _animChangeValue;
        [FieldAttr(152, false)] public igGuiAnimationTag? _animFailChangeValue;
        [FieldAttr(160, false)] public igGuiPlaceable? _textPlaceable;
        [FieldAttr(168)] public int _width = 2;
        [FieldAttr(172)] public int _decimalPlaces;
        [FieldAttr(176)] public float _interval = 1.0f;
        [FieldAttr(180)] public float _minimumValue;
        [FieldAttr(184)] public float _maximumValue = 10.0f;
        [FieldAttr(192, false)] public igGuiPlaceable? _decrementPlaceable;
        [FieldAttr(200, false)] public igGuiPlaceable? _incrementPlaceable;
        [FieldAttr(208)] public EIncrementDirection _incrementDirection;
        [FieldAttr(212)] public bool _wrapValues;
        [FieldAttr(216)] public EGuiMenuSound _onChangeValueSound = EGuiMenuSound.eGMS_Confirm;
        [FieldAttr(220)] public EGuiMenuSound _onChangeValueFailSound;
        [FieldAttr(224)] public igGuiAnimationCategory? _animationCategory;
        [FieldAttr(232)] public float _currentValue;
        [FieldAttr(236)] public float _lastSavedValue;
    }
}
