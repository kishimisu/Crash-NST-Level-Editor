namespace Alchemy
{
    // VSC object extracted from: common_C1_BossCortex_TargetEntityHandler_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_C1_BossCortex_TargetEntityHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public bool _IsDestroySelfOnMoveToXOffsetDone;
        [FieldAttr(48)] public igHandleMetaField _BlueHazardTemplate = new();
        [FieldAttr(56)] public float _MoveToXOffset;
        [FieldAttr(60)] public float _MoveToXOffsetSpeed;
    }
}
