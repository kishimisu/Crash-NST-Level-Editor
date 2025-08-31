namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscClampVec3fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _value;
        [FieldAttr(24)] public igVscVec3fAccessor? _minValue;
        [FieldAttr(32)] public igVscVec3fAccessor? _maxValue;
        [FieldAttr(40)] public igVscVec3fAccessor? _result;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
