namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscLogicalORNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscBoolAccessor? _a;
        [FieldAttr(24)] public igVscBoolAccessor? _b;
        [FieldAttr(32)] public igVscBoolAccessor? _result;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
