namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscAbsFloatNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _input;
        [FieldAttr(24)] public igVscFloatAccessor? _absoluteValue;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
