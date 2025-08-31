namespace Alchemy
{
    // VSC object extracted from: common_C1_BossCortex_ReturnProjectileStageHandler_c.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class common_C1_BossCortex_ReturnProjectileStageHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public EigEaseType _MoveEaseType;
        [FieldAttr(44)] public EigEaseType _SuperStageScaleUpEaseType;
        [FieldAttr(48)] public igHandleMetaField _ReturnProjectileData = new();
        [FieldAttr(56)] public float _MoveSpeed;
        [FieldAttr(60)] public float _MoveEaseRatioIn;
        [FieldAttr(64)] public float _MoveEaseRatioOut;
        [FieldAttr(68)] public float _SuperStageScaleUpTime;
        [FieldAttr(72)] public float _SuperStageScaleUpEaseRatioIn;
        [FieldAttr(76)] public float _SuperStageScaleUpEaseRatioOut;
        [FieldAttr(80)] public float _SuperStageScaleUp;
        [FieldAttr(88)] public igHandleMetaField _Sound_0x58 = new();
        [FieldAttr(96)] public igHandleMetaField _Sound_0x60 = new();
    }
}
