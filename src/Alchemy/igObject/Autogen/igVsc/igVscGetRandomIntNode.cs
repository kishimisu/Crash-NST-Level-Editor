namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscGetRandomIntNode : igVscActionNode
    {
        [FieldAttr(16, false)] public igVscIntAccessor? _min;
        [FieldAttr(24, false)] public igVscIntAccessor? _max;
        [FieldAttr(32, false)] public igVscObjectAccessor? _randomGenerator;
        [FieldAttr(40, false)] public igVscIntAccessor? _result;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
