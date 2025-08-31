namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igVscCompareFloatNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _a;
        [FieldAttr(24)] public igVscFloatAccessor? _b;
        [FieldAttr(32, false)] public igVscActionNode? _greaterThan;
        [FieldAttr(40, false)] public igVscActionNode? _greaterThanOrEqualTo;
        [FieldAttr(48, false)] public igVscActionNode? _equalTo;
        [FieldAttr(56, false)] public igVscActionNode? _notEqualTo;
        [FieldAttr(64, false)] public igVscActionNode? _lessThanOrEqualTo;
        [FieldAttr(72, false)] public igVscActionNode? _lessThan;
    }
}
