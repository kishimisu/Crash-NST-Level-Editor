namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igVscLerpLoopedNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _from;
        [FieldAttr(24)] public igVscFloatAccessor? _to;
        [FieldAttr(32)] public igVscFloatAccessor? _rangeLow;
        [FieldAttr(40)] public igVscFloatAccessor? _rangeHigh;
        [FieldAttr(48)] public igVscFloatAccessor? _percent;
        [FieldAttr(56)] public igVscFloatAccessor? _result;
        [FieldAttr(64, false)] public igVscActionNode? _out;
    }
}
