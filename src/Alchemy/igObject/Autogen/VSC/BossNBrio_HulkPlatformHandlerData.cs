namespace Alchemy
{
    // VSC object extracted from: BossNBrio_HulkPlatformHandler_c.igz

    [ObjectAttr(88, metaType: typeof(CVscComponentData))]
    public class BossNBrio_HulkPlatformHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public EigEaseType _SpawnInScaleEaseType;
        [FieldAttr(44)] public EigEaseType _FallEaseType;
        [FieldAttr(48)] public float _FallTime;
        [FieldAttr(52)] public float _FallEaseRatioIn;
        [FieldAttr(56)] public float _FallEaseRatioOut;
        [FieldAttr(60)] public float _SpawnInScaleTime;
        [FieldAttr(64)] public float _SpawnInScaleEaseRatioIn;
        [FieldAttr(68)] public float _SpawnInScaleEaseRatioOut;
        [FieldAttr(72)] public float _VfxFallImpactSpawnOnFallTimeRatio;
        [FieldAttr(80)] public igHandleMetaField _VfxFallImpactData = new();
    }
}
