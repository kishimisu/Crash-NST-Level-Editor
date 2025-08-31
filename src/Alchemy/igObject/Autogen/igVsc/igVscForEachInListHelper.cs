namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igVscForEachInListHelper : igVscPlaceable
    {
        [FieldAttr(16)] public igVscObjectAccessor? _list;
        [FieldAttr(24)] public igVscAccessor? _current;
        [FieldAttr(32)] public igVscIntAccessor? _internalCounter;
        [FieldAttr(40)] public igVscIntAccessor? _index;
        [FieldAttr(48, false)] public igMetaObjectInstance? _listMetaObject;
        [FieldAttr(56, false)] public igMetaObjectInstance? _listBaseMetaObject;
        [FieldAttr(64, false)] public igVscActionNode? _iteration;
        [FieldAttr(72, false)] public igVscActionNode? _done;
    }
}
