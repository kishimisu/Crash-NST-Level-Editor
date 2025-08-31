namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscDistanceBetweenVec3fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _positionA;
        [FieldAttr(24)] public igVscVec3fAccessor? _positionB;
        [FieldAttr(32)] public igVscFloatAccessor? _distance;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
