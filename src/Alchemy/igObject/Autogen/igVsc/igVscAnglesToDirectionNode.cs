namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscAnglesToDirectionNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _vector;
        [FieldAttr(24)] public igVscVec3fAccessor? _result;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
