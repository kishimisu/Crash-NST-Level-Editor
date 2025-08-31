namespace Alchemy
{
    [ObjectAttr(120, 8, metaObject: true)]
    public class CNovaCollisionInfo : Object
    {
        [FieldAttr(32)] public igHandleMetaField _contactEntity = new();
        [FieldAttr(40)] public igVec3fMetaField _contactPoint = new();
        [FieldAttr(52)] public igVec3fMetaField _contactNormal = new();
        [FieldAttr(64)] public igVec3fMetaField _faceNormal = new();
        [FieldAttr(80)] public CHavokRigidBodyMetaField _contactBody = new();
        [FieldAttr(96)] public uint _contactShapeKey;
        [FieldAttr(104)] public igHandleMetaField _contactMaterial = new();
        [FieldAttr(112)] public float _collisionDistance;
        [FieldAttr(116)] public bool _hitSomething;
        [FieldAttr(117)] public bool _setFaceNormal;
    }
}
