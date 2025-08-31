namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscNegateVec3fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _value;
        [FieldAttr(24)] public igVscVec3fAccessor? _output;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
