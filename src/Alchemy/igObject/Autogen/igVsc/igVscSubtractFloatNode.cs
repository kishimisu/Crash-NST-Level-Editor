namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscSubtractFloatNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _a;
        [FieldAttr(24)] public igVscFloatAccessor? _b;
        [FieldAttr(32)] public igVscFloatAccessor? _return;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
