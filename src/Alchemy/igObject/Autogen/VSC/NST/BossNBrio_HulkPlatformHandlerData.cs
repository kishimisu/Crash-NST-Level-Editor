namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class BossNBrio_HulkPlatformHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public EigEaseType _SpawnInScaleEaseType;
        [FieldAttr(nst: 44, ctr: 36)] public EigEaseType _FallEaseType;
        [FieldAttr(nst: 48, ctr: 40)] public float _FallTime;
        [FieldAttr(nst: 52, ctr: 44)] public float _FallEaseRatioIn;
        [FieldAttr(nst: 56, ctr: 48)] public float _FallEaseRatioOut;
        [FieldAttr(nst: 60, ctr: 52)] public float _SpawnInScaleTime;
        [FieldAttr(nst: 64, ctr: 56)] public float _SpawnInScaleEaseRatioIn;
        [FieldAttr(nst: 68, ctr: 60)] public float _SpawnInScaleEaseRatioOut;
        [FieldAttr(nst: 72, ctr: 64)] public float _VfxFallImpactSpawnOnFallTimeRatio;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _VfxFallImpactData = new();
    }
}
