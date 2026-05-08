namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class B203_TinyTiger_BossEncounterData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _EntityVariable = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Checkpoint = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Query_Filter = new();
    }
}
