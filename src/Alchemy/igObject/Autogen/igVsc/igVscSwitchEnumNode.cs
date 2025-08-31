namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscSwitchEnumNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscEnumAccessor? _choice;
        [FieldAttr(24)] public igEnumVscActionNodeHashTable? _outputs;
        [FieldAttr(32, false)] public igVscActionNode? _outOfRange;
    }
}
