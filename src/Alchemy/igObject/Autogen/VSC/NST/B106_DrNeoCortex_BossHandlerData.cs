namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class B106_DrNeoCortex_BossHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _BossStageList = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _IntroBehaviorDelayStart;
        [FieldAttr(nst: 52, ctr: 44)] public int _Int;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float;
    }
}
