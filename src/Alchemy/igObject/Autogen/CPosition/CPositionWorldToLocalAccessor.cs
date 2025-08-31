namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CPositionWorldToLocalAccessor : igVscVec3fAccessor
    {
        [FieldAttr(24)] public igVscObjectAccessor? _target;
        [FieldAttr(32)] public igVscObjectAccessor? _boltPoint;
        [FieldAttr(40)] public igVscVec3fAccessor? _vector;
    }
}
