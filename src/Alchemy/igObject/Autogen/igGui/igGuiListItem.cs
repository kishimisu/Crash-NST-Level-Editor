namespace Alchemy
{
    [ObjectAttr(136, 8)]
    public class igGuiListItem : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _templateItem = new();
        [FieldAttr(24)] public bool _newlyAdded = true;
        [FieldAttr(25)] public bool _newPlaceable;
        [FieldAttr(26)] public bool _visible;
        [FieldAttr(32)] public igGuiPlaceable? _placeable;
        [FieldAttr(40)] public igVec2fMetaField _min = new();
        [FieldAttr(48)] public igVec2fMetaField _max = new();
        [FieldAttr(56, false)] public igGuiListItem? _previous;
        [FieldAttr(64, false)] public igGuiListItem? _next;
        [FieldAttr(72, false)] public igGuiListItem? _rowPrevious;
        [FieldAttr(80, false)] public igGuiListItem? _rowNext;
        [FieldAttr(88)] public int _focusCount;
        [FieldAttr(96)] public string? _label = null;
        [FieldAttr(104)] public igGuiListItemVscDelegateMetaField _itemDelegate = new();
        [FieldAttr(120)] public igVscDelegateMetaField _spawnedDelegate = new();
    }
}
