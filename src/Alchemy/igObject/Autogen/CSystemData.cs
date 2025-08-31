namespace Alchemy
{
    [ObjectAttr(328, 8)]
    public class CSystemData : igSingleton
    {
        [FieldAttr(16)] public CPlayerSystemData? _playerSystemData;
        [FieldAttr(24)] public CGlobalTuningData? _globalTuningData;
        [FieldAttr(32)] public CDamageData? _superdropDamage;
        [FieldAttr(40)] public CCombatFxData? _combatFxData;
        [FieldAttr(48)] public igHandleMetaField _superchargeDamageNumberMaterial = new();
        [FieldAttr(56)] public CDebugSystemData? _debugData;
        [FieldAttr(64)] public CCollisionMaterialHandleList? _globalCollisionMaterials;
        [FieldAttr(72)] public float _minimumWallAngle = 60.0f;
        [FieldAttr(76)] public float _gravity = -384.0f;
        [FieldAttr(80)] public bool _entityVolumeCullingEnabled = true;
        [FieldAttr(88)] public CCharacterAttributeStringHashTable? _characterAttributeNames;
        [FieldAttr(96)] public CVehicleStatStringHashTable? _vehicleStatNames;
        [FieldAttr(104)] public CModLocationStringHashTable? _modNames;
        [FieldAttr(112)] public CModLocationStringHashTable? _modNamesPlural;
        [FieldAttr(120)] public igStringRefList? _teamFactionNames;
        [FieldAttr(128)] public CPlatformControllerVfxTable? _interactionPlatformVfxData;
        [FieldAttr(136)] public CPlatformControllerVfxTable? _interactionMashPlatformVfxData;
        [FieldAttr(144)] public CPlatformControllerToAnalogStickVfxTable? _interactionAnalogStickDirectionPlatformVfxData;
        [FieldAttr(152)] public CQueryFilter? _lightCoreBlastTargetFilter;
        [FieldAttr(160)] public CDamageData? _lightCoreBlastDamage;
        [FieldAttr(168)] public igStringRefList? _heroVolumeGroups;
        [FieldAttr(176)] public float _muteFadeTime = 0.1f;
        [FieldAttr(184)] public CFadeInPresetData? _defaultFadeIn;
        [FieldAttr(192)] public igEntity? _majorCollectibleReplacement;
        [FieldAttr(200)] public CPlayerRespawnData? _respawnData;
        [FieldAttr(208)] public CControllerVibrationDataPresetTable? _vibrationPresets;
        [FieldAttr(216)] public CMobileGameStatBoostTable? _mobileBuffs;
        [FieldAttr(224)] public string? _coopRespawnButtonHint = "Hold %s to respawn your skylander near the other player.";
        [FieldAttr(232)] public float _coopRespawnButtonHintDuration = 6.0f;
        [FieldAttr(236)] public float _coopRespawnButtonPreHintDelay = 30.0f;
        [FieldAttr(240)] public float _coopRespawnButtonHintTetherLimitDelay = 3.0f;
        [FieldAttr(244)] public float _holdRespawnButtonTriggerTime = 1.0f;
        [FieldAttr(248)] public EXBUTTON _coopRespawnButton = EXBUTTON.L1;
        [FieldAttr(256)] public string? _difficultyFormat = "Difficulty";
        [FieldAttr(264)] public igStringRefList? _difficultyStrings;
        [FieldAttr(272)] public CCollectibleSystemData? _collectibleSystemData;
        [FieldAttr(280)] public CNetworkVisualizationComponentData? _networkVisualizationComponent;
        [FieldAttr(288)] public CGameSoundMusicSettings? _defaultMusicSettings;
        [FieldAttr(296)] public CVehicleSystemData? _vehicleSystemData;
        [FieldAttr(304)] public CSaveSystemData? _saveSystemData;
        [FieldAttr(312)] public CUIDebugMenuList? _debugMenus;
        [FieldAttr(320)] public CSystemInitializerList? _systemInitializers;
    }
}
