namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscSwitch02Node : igVscActionNode
    {
        [FieldAttr(16)] public igVscIntAccessor? _choice;
        [FieldAttr(24, false)] public igVscActionNode? _output0;
        [FieldAttr(32, false)] public igVscActionNode? _output1;
        [FieldAttr(40, false)] public igVscActionNode? _outOfRange;
    }
}
