namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Crash_Ride_PlaneData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Zone_Info_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Zone_Info_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Zone_Info_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity_Tag = new();
    }
}
