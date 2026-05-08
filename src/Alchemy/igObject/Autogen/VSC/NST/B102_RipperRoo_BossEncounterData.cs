namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class B102_RipperRoo_BossEncounterData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _EntityVariable_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _EntityVariable_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Waypoint_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Waypoint_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public int _Int;
        [FieldAttr(nst: 76, ctr: 68)] public float _Float_0x4c;
        [FieldAttr(nst: 80, ctr: 72)] public float _Float_0x50;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Camera = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 104, ctr: 96)] public float _Float_0x68;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _igEntity_List = new();
    }
}
