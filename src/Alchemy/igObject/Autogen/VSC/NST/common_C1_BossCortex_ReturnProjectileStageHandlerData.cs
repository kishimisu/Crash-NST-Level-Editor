namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class common_C1_BossCortex_ReturnProjectileStageHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public EigEaseType _MoveEaseType;
        [FieldAttr(nst: 44, ctr: 36)] public EigEaseType _SuperStageScaleUpEaseType;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _ReturnProjectileData = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _MoveSpeed;
        [FieldAttr(nst: 60, ctr: 52)] public float _MoveEaseRatioIn;
        [FieldAttr(nst: 64, ctr: 56)] public float _MoveEaseRatioOut;
        [FieldAttr(nst: 68, ctr: 60)] public float _SuperStageScaleUpTime;
        [FieldAttr(nst: 72, ctr: 64)] public float _SuperStageScaleUpEaseRatioIn;
        [FieldAttr(nst: 76, ctr: 68)] public float _SuperStageScaleUpEaseRatioOut;
        [FieldAttr(nst: 80, ctr: 72)] public float _SuperStageScaleUp;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Sound_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Sound_0x60 = new();
    }
}
