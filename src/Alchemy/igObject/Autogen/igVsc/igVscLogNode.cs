namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscLogNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscStringAccessor? _channel;
        [FieldAttr(24)] public igVscStringAccessor? _prefix;
        [FieldAttr(32)] public igVscAccessor? _value;
        [FieldAttr(40)] public igVscStringAccessor? _postfix;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
