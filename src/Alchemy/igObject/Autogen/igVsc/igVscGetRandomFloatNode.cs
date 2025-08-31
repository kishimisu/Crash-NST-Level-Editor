namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscGetRandomFloatNode : igVscActionNode
    {
        [FieldAttr(16, false)] public igVscFloatAccessor? _min;
        [FieldAttr(24, false)] public igVscFloatAccessor? _max;
        [FieldAttr(32, false)] public igVscObjectAccessor? _randomGenerator;
        [FieldAttr(40, false)] public igVscFloatAccessor? _result;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
