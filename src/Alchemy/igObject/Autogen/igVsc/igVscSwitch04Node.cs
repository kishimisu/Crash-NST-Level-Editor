namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igVscSwitch04Node : igVscActionNode
    {
        [FieldAttr(16)] public igVscIntAccessor? _choice;
        [FieldAttr(24, false)] public igVscActionNode? _output0;
        [FieldAttr(32, false)] public igVscActionNode? _output1;
        [FieldAttr(40, false)] public igVscActionNode? _output2;
        [FieldAttr(48, false)] public igVscActionNode? _output3;
        [FieldAttr(56, false)] public igVscActionNode? _outOfRange;
    }
}
