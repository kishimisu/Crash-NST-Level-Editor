namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class igVscFormatStringNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscStringAccessor? _input;
        [FieldAttr(24)] public igVscAccessor? _param0;
        [FieldAttr(32)] public igVscAccessor? _param1;
        [FieldAttr(40)] public igVscAccessor? _param2;
        [FieldAttr(48)] public igVscAccessor? _param3;
        [FieldAttr(56)] public igVscAccessor? _param4;
        [FieldAttr(64)] public igVscAccessor? _param5;
        [FieldAttr(72)] public igVscAccessor? _param6;
        [FieldAttr(80)] public igVscAccessor? _param7;
        [FieldAttr(88)] public igVscAccessor? _param8;
        [FieldAttr(96)] public igVscAccessor? _param9;
        [FieldAttr(104)] public igVscStringAccessor? _output;
        [FieldAttr(112, false)] public igVscActionNode? _out;
    }
}
