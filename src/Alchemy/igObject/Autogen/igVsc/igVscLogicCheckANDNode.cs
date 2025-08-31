namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igVscLogicCheckANDNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscBoolAccessor? _a;
        [FieldAttr(24)] public igVscBoolAccessor? _b;
        [FieldAttr(32)] public igVscBoolAccessor? _result;
        [FieldAttr(40, false)] public igVscActionNode? _resultTrue;
        [FieldAttr(48, false)] public igVscActionNode? _resultFalse;
        [FieldAttr(56, false)] public igVscActionNode? _out;
    }
}
