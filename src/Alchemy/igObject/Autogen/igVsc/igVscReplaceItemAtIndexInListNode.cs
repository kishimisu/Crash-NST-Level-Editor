namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igVscReplaceItemAtIndexInListNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscObjectAccessor? _sourceList;
        [FieldAttr(24)] public igVscAccessor? _newItem;
        [FieldAttr(32)] public igVscIntAccessor? _index;
        [FieldAttr(40)] public igVscObjectAccessor? _modifiedList;
        [FieldAttr(48, false)] public igMetaObjectInstance? _listMetaObject;
        [FieldAttr(56, false)] public igMetaObjectInstance? _listBaseMetaObject;
        [FieldAttr(64, false)] public igVscActionNode? _out;
    }
}
