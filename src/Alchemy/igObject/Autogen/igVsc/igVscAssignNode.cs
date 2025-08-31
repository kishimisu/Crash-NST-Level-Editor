namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscAssignNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscAccessor? _a;
        [FieldAttr(24)] public igVscAccessor? _return;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
