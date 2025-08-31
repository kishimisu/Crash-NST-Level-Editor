namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscLerpFloatNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _from;
        [FieldAttr(24)] public igVscFloatAccessor? _to;
        [FieldAttr(32)] public igVscFloatAccessor? _percent;
        [FieldAttr(40)] public igVscFloatAccessor? _result;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
