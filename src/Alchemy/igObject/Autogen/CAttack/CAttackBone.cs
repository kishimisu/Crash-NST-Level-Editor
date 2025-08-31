namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CAttackBone : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _boltPoint = new();
        [FieldAttr(24)] public igVec3fMetaField _positionOffset = new();
        [FieldAttr(36)] public igVec3fMetaField _anglesOffset = new();
    }
}
