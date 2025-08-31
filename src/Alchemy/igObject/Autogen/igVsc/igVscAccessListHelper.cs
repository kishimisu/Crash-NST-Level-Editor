namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igVscAccessListHelper : igVscPlaceable
    {
        [FieldAttr(16)] public igVscObjectAccessor? _list;
        [FieldAttr(24)] public igVscIntAccessor? _index;
        [FieldAttr(32)] public igVscAccessor? _item;
        [FieldAttr(40, false)] public igMetaObjectInstance? _listMetaObject;
        [FieldAttr(48, false)] public igMetaObjectInstance? _listBaseMetaObject;
        [FieldAttr(56, false)] public igVscActionNode? _out;
    }
}
