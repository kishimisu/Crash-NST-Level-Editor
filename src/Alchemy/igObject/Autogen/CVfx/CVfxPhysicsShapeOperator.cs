namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CVfxPhysicsShapeOperator : igVfxOperator
    {
        [FieldAttr(24)] public CVfxPhysicsShape? _shape;
        [FieldAttr(32)] public uint _collisionFlags = 287;
        [FieldAttr(36)] public float _mass = 1.0f;
        [FieldAttr(40)] public igHandleMetaField _collisionMaterial = new();
        [FieldAttr(48)] public igHandleMetaField _motionProperties = new();
        [FieldAttr(56)] public igVec3fMetaField _centerOfMassOffset = new();
        [FieldAttr(68)] public igVec3fMetaField _localTorqueMultiplier = new();
        [FieldAttr(80)] public bool _useMassAsDensity;
        [FieldAttr(81)] public bool _useDebrisLayer = true;
        [FieldAttr(84)] public u32 /* igStructMetaField */ _instance;
        [FieldAttr(88)] public CHavokShapeMetaField _cachedShape = new();
        [FieldAttr(96)] public igVec3fMetaField _cachedShapeBounds = new();
    }
}
