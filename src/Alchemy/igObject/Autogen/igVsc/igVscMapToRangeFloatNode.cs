namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igVscMapToRangeFloatNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _input;
        [FieldAttr(24)] public igVscBoolAccessor? _clampInput;
        [FieldAttr(32)] public igVscFloatAccessor? _inputLow;
        [FieldAttr(40)] public igVscFloatAccessor? _inputHigh;
        [FieldAttr(48)] public igVscFloatAccessor? _outputLow;
        [FieldAttr(56)] public igVscFloatAccessor? _outputHigh;
        [FieldAttr(64)] public igVscFloatAccessor? _output;
        [FieldAttr(72, false)] public igVscActionNode? _out;
    }
}
