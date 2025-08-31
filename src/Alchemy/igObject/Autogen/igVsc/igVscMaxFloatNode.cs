namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscMaxFloatNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _a;
        [FieldAttr(24)] public igVscFloatAccessor? _b;
        [FieldAttr(32)] public igVscFloatAccessor? _output;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
