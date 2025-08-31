namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscCompareStringNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscStringAccessor? _a;
        [FieldAttr(24)] public igVscStringAccessor? _b;
        [FieldAttr(32, false)] public igVscActionNode? _equalTo;
        [FieldAttr(40, false)] public igVscActionNode? _notEqualTo;
        [FieldAttr(48)] public igVscBoolAccessor? _ignoreCase;
    }
}
