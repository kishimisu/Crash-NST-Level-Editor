namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscCompareBoolNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscBoolAccessor? _a;
        [FieldAttr(24)] public igVscBoolAccessor? _b;
        [FieldAttr(32, false)] public igVscActionNode? _equalTo;
        [FieldAttr(40, false)] public igVscActionNode? _notEqualTo;
    }
}
