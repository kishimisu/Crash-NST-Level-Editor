namespace Alchemy
{
    [ObjectAttr(88, 16)]
    public class igGuiEffect : igGuiAsset
    {
        [FieldAttr(32)] public igGuiEventEffectSpawned? _spawnedEffectEvent;
        [FieldAttr(40)] public igHandleMetaField _effect = new();
        [FieldAttr(48)] public float _distanceFromCamera = 50.0f;
        [FieldAttr(52)] public u16 _layer = 65535;
        [FieldAttr(56)] public igVfxManager.EffectKillType _killType;
        [FieldAttr(60)] public igVfxManager.ESpawnGroup _spawnGroup = igVfxManager.ESpawnGroup.kSpawnGroup1;
        [FieldAttr(64)] public bool _setBoltParametersFromTexCoords;
        [FieldAttr(72)] public igHandleMetaField _spawnedEffect = new();
        [FieldAttr(80)] public igGuiPlaceableBolt? _bolt;
    }
}
