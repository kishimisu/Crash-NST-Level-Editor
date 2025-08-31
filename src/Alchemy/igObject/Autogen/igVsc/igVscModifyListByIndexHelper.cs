namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igVscModifyListByIndexHelper : igVscPlaceable
    {
        [FieldAttr(16)] public igVscObjectAccessor? _sourceList;
        [FieldAttr(24)] public igVscAccessor? _insertItem;
        [FieldAttr(32)] public igVscIntAccessor? _index;
        [FieldAttr(40)] public igVscObjectAccessor? _modifiedList;
        [FieldAttr(48)] public igVscIntAccessor? _size;
        [FieldAttr(56, false)] public igMetaObjectInstance? _listMetaObject;
        [FieldAttr(64, false)] public igMetaObjectInstance? _listBaseMetaObject;
        [FieldAttr(72, false)] public igVscActionNode? _out;
    }
}
