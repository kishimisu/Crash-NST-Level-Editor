namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CRotationLocalToWorldAccessor : igVscVec3fAccessor
    {
        [FieldAttr(24)] public igVscObjectAccessor? _target;
        [FieldAttr(32)] public igVscVec3fAccessor? _rotation;
    }
}
