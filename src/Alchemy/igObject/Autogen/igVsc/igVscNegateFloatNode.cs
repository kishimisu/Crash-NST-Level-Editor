namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscNegateFloatNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _value;
        [FieldAttr(24)] public igVscFloatAccessor? _output;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
