namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscDistanceVec3fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _position;
        [FieldAttr(24)] public igVscVec3fAccessor? _relativeTo;
        [FieldAttr(32)] public igVscFloatAccessor? _distance;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
