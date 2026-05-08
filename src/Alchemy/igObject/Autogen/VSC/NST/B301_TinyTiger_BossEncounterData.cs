namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class B301_TinyTiger_BossEncounterData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Waypoint_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public float _Float_0x50;
        [FieldAttr(nst: 84, ctr: 76)] public float _Float_0x54;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Waypoint_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public float _Float_0x68;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Game_Bool_Variable = new();
    }
}
