namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igVscSetYawVec3fNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _position;
        [FieldAttr(24)] public igVscVec3fAccessor? _relativeTo;
        [FieldAttr(32)] public igVscFloatAccessor? _yaw;
        [FieldAttr(40)] public igVscVec3fAccessor? _adjustedPosition;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
