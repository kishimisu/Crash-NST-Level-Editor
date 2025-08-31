namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CCollisionMaterial : igNamedObject
    {
        [FieldAttr(24)] public igHandleMetaField _surfaceInfo = new();
        [FieldAttr(32)] public float _dynamicFriction = 0.5f;
        [FieldAttr(36)] public float _staticFriction = 0.5f;
        [FieldAttr(40)] public float _restitution;
        [FieldAttr(44)] public bool _isMutable;
        [FieldAttr(45)] public bool _enableCollisionResponse = true;
        [FieldAttr(46)] public bool _finalizeCalled;
        [FieldAttr(48)] public CSurfaceVelocity? _surfaceVelocity;
        [FieldAttr(56)] public u32 /* igStructMetaField */ _materialId;
    }
}
