namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscPowerNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _value;
        [FieldAttr(24)] public igVscFloatAccessor? _power;
        [FieldAttr(32)] public igVscFloatAccessor? _result;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
