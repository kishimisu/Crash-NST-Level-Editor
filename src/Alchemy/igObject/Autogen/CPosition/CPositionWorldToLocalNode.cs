namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CPositionWorldToLocalNode : igVscActionNode
    {
        [FieldAttr(16)] public igVscObjectAccessor? _target;
        [FieldAttr(24)] public igVscObjectAccessor? _boltPoint;
        [FieldAttr(32)] public igVscVec3fAccessor? _vector;
        [FieldAttr(40)] public igVscVec3fAccessor? _result;
        [FieldAttr(48, false)] public igVscActionNode? _out;
    }
}
