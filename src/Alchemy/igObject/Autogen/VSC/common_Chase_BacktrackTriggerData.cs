namespace Alchemy
{
    // VSC object extracted from: common_Chase_BacktrackTrigger.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_Chase_BacktrackTriggerData : CVscComponentData
    {
        [FieldAttr(40)] public string? _HazardDeathState = null;
        [FieldAttr(48)] public igHandleMetaField _Entity = new();
        [FieldAttr(56)] public string? _String = null;
    }
}
