namespace Alchemy
{
    // VSC object extracted from: common_BossLookAtTargetHandler.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class B106_DrNeoCortex_BossLookAt_HandlerData : CVscComponentData
    {
        [FieldAttr(40)] public EigEaseType _LookAtTargetStartEaseType;
        [FieldAttr(44)] public float _LookAtTargetStartTime;
        [FieldAttr(48)] public float _LookAtTargetStartEaseRatioIn;
        [FieldAttr(52)] public float _LookAtTargetStartEaseRatioOut;
        [FieldAttr(56)] public bool _Bool;
    }
}
