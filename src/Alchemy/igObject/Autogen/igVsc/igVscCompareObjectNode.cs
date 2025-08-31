namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscCompareObjectNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscAccessor? _a;
        [FieldAttr(24)] public igVscAccessor? _b;
        [FieldAttr(32, false)] public igVscActionNode? _same;
        [FieldAttr(40, false)] public igVscActionNode? _different;
    }
}
