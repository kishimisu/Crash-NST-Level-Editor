namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class igVscIntCounterHelper : igVscPlaceable
    {
        [FieldAttr(16)] public igVscObjectAccessor? _counter;
        [FieldAttr(24)] public igVscIntAccessor? _start;
        [FieldAttr(32)] public igVscIntAccessor? _countBy;
        [FieldAttr(40)] public igVscIntAccessor? _compare;
        [FieldAttr(48)] public igVscIntAccessor? _current;
        [FieldAttr(56, false)] public igVscActionNode? _greaterThan;
        [FieldAttr(64, false)] public igVscActionNode? _greaterThanOrEqualTo;
        [FieldAttr(72, false)] public igVscActionNode? _equalTo;
        [FieldAttr(80, false)] public igVscActionNode? _notEqualTo;
        [FieldAttr(88, false)] public igVscActionNode? _lessThanOrEqualTo;
        [FieldAttr(96, false)] public igVscActionNode? _lessThan;
    }
}
