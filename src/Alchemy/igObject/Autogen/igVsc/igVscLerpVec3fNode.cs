namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscLerpVec3fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _from;
        [FieldAttr(24)] public igVscVec3fAccessor? _to;
        [FieldAttr(32)] public igVscFloatAccessor? _percent;
        [FieldAttr(40)] public igVscVec3fAccessor? _result;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
