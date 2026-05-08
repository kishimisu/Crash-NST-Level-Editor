namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Chase_BacktrackTriggerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _HazardDeathState = null;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 56, ctr: 48)] public string? _String = null;
    }
}
