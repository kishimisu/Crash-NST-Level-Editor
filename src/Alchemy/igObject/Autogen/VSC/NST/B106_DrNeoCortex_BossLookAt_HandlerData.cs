namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class B106_DrNeoCortex_BossLookAt_HandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public EigEaseType _LookAtTargetStartEaseType;
        [FieldAttr(nst: 44, ctr: 36)] public float _LookAtTargetStartTime;
        [FieldAttr(nst: 48, ctr: 40)] public float _LookAtTargetStartEaseRatioIn;
        [FieldAttr(nst: 52, ctr: 44)] public float _LookAtTargetStartEaseRatioOut;
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool;
    }
}
