namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscSineNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscFloatAccessor? _angle;
        [FieldAttr(24)] public igVscFloatAccessor? _sine;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
