namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igVscModifyListHelper : igVscPlaceable
    {
        [FieldAttr(16)] public igVscObjectAccessor? _sourceList;
        [FieldAttr(24)] public igVscAccessor? _item;
        [FieldAttr(32)] public igVscObjectAccessor? _modifiedList;
        [FieldAttr(40)] public igVscIntAccessor? _size;
        [FieldAttr(48, false)] public igMetaObjectInstance? _listMetaObject;
        [FieldAttr(56, false)] public igMetaObjectInstance? _listBaseMetaObject;
        [FieldAttr(64, false)] public igVscActionNode? _out;
    }
}
