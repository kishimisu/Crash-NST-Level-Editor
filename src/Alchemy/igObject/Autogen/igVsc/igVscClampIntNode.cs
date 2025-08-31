namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscClampIntNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscIntAccessor? _value;
        [FieldAttr(24)] public igVscIntAccessor? _minValue;
        [FieldAttr(32)] public igVscIntAccessor? _maxValue;
        [FieldAttr(40)] public igVscIntAccessor? _result;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
