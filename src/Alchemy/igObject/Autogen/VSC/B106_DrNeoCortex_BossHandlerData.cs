namespace Alchemy
{
    // VSC object extracted from: B106_DrNeoCortex_BossHandler_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class B106_DrNeoCortex_BossHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _BossStageList = new();
        [FieldAttr(48)] public float _IntroBehaviorDelayStart;
        [FieldAttr(52)] public int _Int;
        [FieldAttr(56)] public float _Float;
    }
}
