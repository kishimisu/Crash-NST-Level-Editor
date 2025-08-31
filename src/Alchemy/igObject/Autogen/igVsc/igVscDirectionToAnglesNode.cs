namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscDirectionToAnglesNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _vector;
        [FieldAttr(24)] public igVscBoolAccessor? _normalize;
        [FieldAttr(32)] public igVscVec3fAccessor? _result;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
