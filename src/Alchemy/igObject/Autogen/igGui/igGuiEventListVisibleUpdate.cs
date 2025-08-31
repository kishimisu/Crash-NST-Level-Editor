namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igGuiEventListVisibleUpdate : igGuiEvent
    {
        [FieldAttr(24, false)] public igGuiPlaceable? _list;
        [FieldAttr(32)] public float _scrollSize;
        [FieldAttr(36)] public int _visibleStartIndex;
        [FieldAttr(40)] public int _visibleEndIndex;
        [FieldAttr(44)] public bool _limitUp;
        [FieldAttr(45)] public bool _limitDown;
        [FieldAttr(46)] public bool _limitLeft;
        [FieldAttr(47)] public bool _limitRight;
    }
}
