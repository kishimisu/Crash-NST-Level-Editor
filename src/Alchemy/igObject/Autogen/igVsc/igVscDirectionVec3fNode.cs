namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscDirectionVec3fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _fromPosition;
        [FieldAttr(24)] public igVscVec3fAccessor? _toPosition;
        [FieldAttr(32)] public igVscBoolAccessor? _normalize;
        [FieldAttr(40)] public igVscVec3fAccessor? _result;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
