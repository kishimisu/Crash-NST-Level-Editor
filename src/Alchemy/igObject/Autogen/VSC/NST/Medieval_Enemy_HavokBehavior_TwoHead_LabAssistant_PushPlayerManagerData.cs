namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class Medieval_Enemy_HavokBehavior_TwoHead_LabAssistant_PushPlayerManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x34;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Waypoint_List = new();
        [FieldAttr(nst: 64, ctr: 56)] public igVec3fMetaField _Vec_3F = new();
    }
}
