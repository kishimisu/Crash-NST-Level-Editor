namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscMinIntNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscIntAccessor? _a;
        [FieldAttr(24)] public igVscIntAccessor? _b;
        [FieldAttr(32)] public igVscIntAccessor? _output;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
