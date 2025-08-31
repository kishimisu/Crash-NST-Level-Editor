namespace Alchemy
{
    [ObjectAttr(232, 8)]
    public class CGuiBehaviorInitialsEntryDialog : CGuiBehavior
    {
        [FieldAttr(144, false)] public igGuiList? _characterList0;
        [FieldAttr(152, false)] public igGuiList? _characterList1;
        [FieldAttr(160, false)] public igGuiList? _characterList2;
        [FieldAttr(168, false)] public igGuiPlaceable? _upArrow;
        [FieldAttr(176, false)] public igGuiPlaceable? _downArrow;
        [FieldAttr(184)] public int _focusedListIndex;
        [FieldAttr(192)] public igObject[] _characterLists = new igObject[3];
        [FieldAttr(216)] public int[] _lastFocusedListItemIndices = new int[3];
        [FieldAttr(228)] public bool _hasFocusedInitialList;
    }
}
