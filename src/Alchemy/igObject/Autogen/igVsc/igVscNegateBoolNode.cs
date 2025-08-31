namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscNegateBoolNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscBoolAccessor? _value;
        [FieldAttr(24)] public igVscBoolAccessor? _output;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
