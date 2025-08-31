namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscGetRandomVec3fRangedNode : igVscActionNode
    {
        [FieldAttr(16, false)] public igVscVec3fAccessor? _minVec;
        [FieldAttr(24, false)] public igVscVec3fAccessor? _maxVec;
        [FieldAttr(32, false)] public igVscObjectAccessor? _randomGenerator;
        [FieldAttr(40, false)] public igVscVec3fAccessor? _result;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
