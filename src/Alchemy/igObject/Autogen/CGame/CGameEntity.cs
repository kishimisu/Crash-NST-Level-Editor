namespace Alchemy
{
    [ObjectAttr(224, 8)]
    public class CGameEntity : CEntity
    {
        public enum ECastsShadows : uint
        {
            ECS_Archetype = 0,
            ECS_CastsShadows = 1,
            ECS_DoesNotCastShadows = 2,
        }

        public enum EMobileShadowStateOverride : uint
        {
            eMSSO_Archetype = 0,
            eMSSO_CastsShadows = 1,
            eMSSO_ReceivesShadows = 2,
            eMSSO_DoesNotCastOrReceiveShadows = 3,
        }

        [ObjectAttr(4)]
        public class GameEntityPersistentProperties : igBitFieldMetaField
        {
            [FieldAttr(0, size: 2)] public CGameEntity.ECastsShadows _castsShadows;
            [FieldAttr(2, size: 2)] public CGameEntity.EMobileShadowStateOverride _mobileShadowStateOverride;
        }

        [ObjectAttr(4)]
        public class GameEntityProperties : igBitFieldMetaField
        {
            [FieldAttr(0, size: 8)] public u8 _viewportForceDisableFlags;
            [FieldAttr(8, size: 1)] public bool _animActive;
            [FieldAttr(9, size: 1)] public bool _animInReverse;
            [FieldAttr(10, size: 1)] public bool _noKillZ;
            [FieldAttr(11, size: 1)] public bool _hasDestination;
            [FieldAttr(12, size: 1)] public bool _scaleMovementSpeed;
        }

        [FieldAttr(144)] public GameEntityPersistentProperties _gameEntityPersistentProperties = new();
        [FieldAttr(148)] public bool _ignoreOcclusionBoxes;
        [FieldAttr(152)] public GameEntityProperties _gameEntityProperties = new();
        [FieldAttr(156)] public float _lifetimeCache;
        [FieldAttr(160)] public CAttachModelList? _attachModelList;
        [FieldAttr(168)] public igHandleMetaField _overrideRenderMatrixComponent = new();
        [FieldAttr(176)] public CModelInstance? mModel;
        [FieldAttr(184)] public bool mBelowKillZ;
        [FieldAttr(185)] public bool _IsValidModel;
        [FieldAttr(192)] public CFxMaterialRedirectTable? _dynamicModelMaterialOverrides;
        [FieldAttr(200)] public igHandleMetaField _spawnedRenderVfx = new();
        [FieldAttr(208)] public CCloudBundle? _cloudBundle;
        [FieldAttr(216)] public igTimeMetaField _lastNetUpdateTime = new();
    }
}
