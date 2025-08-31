namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class CGameEntityData : CEntityData
    {
        [FieldAttr(56)] public uint _gameEntityFlags = 512;
        [FieldAttr(60)] public igModelInstance.EDistanceCullImportance _distanceCullImportance = igModelInstance.EDistanceCullImportance.kMedium;
        [FieldAttr(64)] public ETeamFilterLayers _collisionLayer = ETeamFilterLayers.eTFL_Entity;
        [FieldAttr(68)] public ECharacterCollisionPriority _collisionPriority = ECharacterCollisionPriority.eCCP_None;
        [FieldAttr(72)] public string? _modelName = null;
        [FieldAttr(80)] public string? _skinName = null;
        [FieldAttr(88)] public CFxMaterialRedirectTable? _materialOverrides;
        [FieldAttr(96)] public igHandleMetaField _collisionMaterial = new();
        [FieldAttr(104)] public bool _castsShadows = true;
        [FieldAttr(108)] public EMobileShadowState _mobileShadowState;
        [FieldAttr(112)] public float _lifetime;
        [FieldAttr(116)] public float _lifetimeModifier;
        [FieldAttr(120)] public EMemoryPoolID _cachedAssetPool = EMemoryPoolID.MP_MAX_POOL;
    }
}
