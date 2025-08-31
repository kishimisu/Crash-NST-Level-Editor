namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscTestObjectNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscAccessor? _object;
        [FieldAttr(24, false)] public igVscActionNode? _boolNonNull;
        [FieldAttr(32, false)] public igVscActionNode? _boolNull;
    }
}
