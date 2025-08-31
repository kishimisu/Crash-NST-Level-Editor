namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CVfxDrawDebrisOperator : igVfxDrawOperator
    {
        [FieldAttr(32)] public string? _modelName = null;
        [FieldAttr(40)] public igStringRefList? _modelNameList;
        [FieldAttr(48)] public uint _collisionFlags = 287;
        [FieldAttr(52)] public bool _useDebrisLayer = true;
        [FieldAttr(56)] public u32 /* igStructMetaField */ _instance;
        [FieldAttr(64)] public CFxMaterialRedirectTable? _materialOverrides;
        [FieldAttr(72)] public igVectorMetaField<CHavokPhysicsSystemDataMetaField> _rigidBodyCache = new();
        [FieldAttr(96)] public igHandleList? _modelCacheHandles;
        [FieldAttr(104)] public float _physicsTimeScale = 1.0f;
        [FieldAttr(108)] public bool _castsShadows = true;
    }
}
