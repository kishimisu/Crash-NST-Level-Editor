namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igVscIsInListNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscObjectAccessor? _list;
        [FieldAttr(24)] public igVscAccessor? _item;
        [FieldAttr(32)] public igVscIntAccessor? _index;
        [FieldAttr(40, false)] public igMetaObjectInstance? _listMetaObject;
        [FieldAttr(48, false)] public igMetaObjectInstance? _listBaseMetaObject;
        [FieldAttr(56, false)] public igVscActionNode? _inList;
        [FieldAttr(64, false)] public igVscActionNode? _notInList;
    }
}
