namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscClampFloatNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _value;
        [FieldAttr(24)] public igVscFloatAccessor? _minValue;
        [FieldAttr(32)] public igVscFloatAccessor? _maxValue;
        [FieldAttr(40)] public igVscFloatAccessor? _result;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
