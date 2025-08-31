namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscCompareNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscAccessor? _a;
        [FieldAttr(24)] public igVscAccessor? _b;
        [FieldAttr(32)] public igVscBoolAccessor? _return;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
