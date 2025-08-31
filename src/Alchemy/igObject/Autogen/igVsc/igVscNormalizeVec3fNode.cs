namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscNormalizeVec3fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _vector;
        [FieldAttr(24)] public igVscVec3fAccessor? _result;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
