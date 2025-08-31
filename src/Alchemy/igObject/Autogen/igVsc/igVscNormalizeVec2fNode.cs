namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscNormalizeVec2fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec2fAccessor? _vector;
        [FieldAttr(24)] public igVscVec2fAccessor? _result;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
