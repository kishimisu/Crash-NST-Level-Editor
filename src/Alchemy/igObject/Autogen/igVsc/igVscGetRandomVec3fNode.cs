namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscGetRandomVec3fNode : igVscActionNode
    {
        [FieldAttr(16, false)] public igVscObjectAccessor? _randomGenerator;
        [FieldAttr(24, false)] public igVscVec3fAccessor? _result;
        [FieldAttr(32, false)] public igVscActionNode? _out;
    }
}
