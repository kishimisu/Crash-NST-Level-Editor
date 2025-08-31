namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscAbsIntNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscIntAccessor? _input;
        [FieldAttr(24)] public igVscIntAccessor? _absoluteValue;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
