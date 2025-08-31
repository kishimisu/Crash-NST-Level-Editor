namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igVscWithinRangeNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _input;
        [FieldAttr(24)] public igVscFloatAccessor? _rangeLow;
        [FieldAttr(32)] public igVscFloatAccessor? _rangeHigh;
        [FieldAttr(40, false)] public igVscActionNode? _yes;
        [FieldAttr(48, false)] public igVscActionNode? _no;
        [FieldAttr(56, false)] public igVscActionNode? _out;
    }
}
