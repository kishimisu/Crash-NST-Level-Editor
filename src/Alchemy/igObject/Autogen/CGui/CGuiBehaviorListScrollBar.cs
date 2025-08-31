namespace Alchemy
{
    [ObjectAttr(216, 8)]
    public class CGuiBehaviorListScrollBar : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiList? _associatedList;
        [FieldAttr(152, false)] public igGuiPlaceable? _scrollCursorPlaceable;
        [FieldAttr(160, false)] public igGuiPlaceable? _scrollBackButton;
        [FieldAttr(168, false)] public igGuiPlaceable? _scrollForwardButton;
        [FieldAttr(176)] public bool _horizontalScroll;
        [FieldAttr(180)] public float _minScrollPosition;
        [FieldAttr(184)] public float _maxScrollPosition;
        [FieldAttr(188)] public float _currentScrollPercentage;
        [FieldAttr(192)] public float _currentScrollCursorPercentage;
        [FieldAttr(196)] public bool _isBeingDragged;
        [FieldAttr(200)] public igGuiInput.EController _touchControl_1;
        [FieldAttr(208, false)] public igGuiPlaceable? _focusedPlaceable;
    }
}
