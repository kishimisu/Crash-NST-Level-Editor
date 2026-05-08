namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class B102_RipperRoo_CratesSpawnerManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public bool _Bool;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Waypoint_List_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Waypoint_List_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _Float;
    }
}
