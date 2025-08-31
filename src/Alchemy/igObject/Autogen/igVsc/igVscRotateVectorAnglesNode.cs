namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscRotateVectorAnglesNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscVec3fAccessor? _direction;
        [FieldAttr(24)] public igVscVec3fAccessor? _rotation;
        [FieldAttr(32)] public igVscVec3fAccessor? _rotated;
        [FieldAttr(40, false)] public igVscActionNode? _out;
    }
}
