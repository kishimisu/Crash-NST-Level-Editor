namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscTestBoolNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscBoolAccessor? _inputBool;
        [FieldAttr(24, false)] public igVscActionNode? _boolTrue;
        [FieldAttr(32, false)] public igVscActionNode? _boolFalse;
    }
}
