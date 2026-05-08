namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_C1_BossCortex_TargetEntityHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _IsDestroySelfOnMoveToXOffsetDone;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _BlueHazardTemplate = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _MoveToXOffset;
        [FieldAttr(nst: 60, ctr: 52)] public float _MoveToXOffsetSpeed;
    }
}
