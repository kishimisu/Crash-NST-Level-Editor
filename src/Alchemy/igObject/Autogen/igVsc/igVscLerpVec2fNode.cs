namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscLerpVec2fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec2fAccessor? _from;
        [FieldAttr(24)] public igVscVec2fAccessor? _to;
        [FieldAttr(32)] public igVscFloatAccessor? _percent;
        [FieldAttr(40)] public igVscVec2fAccessor? _result;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
