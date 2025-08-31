namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscLogicalNOTNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscBoolAccessor? _a;
        [FieldAttr(24)] public igVscBoolAccessor? _result;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
