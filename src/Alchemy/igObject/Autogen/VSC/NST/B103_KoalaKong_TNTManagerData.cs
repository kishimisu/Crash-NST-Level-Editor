namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class B103_KoalaKong_TNTManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Waypoint_List = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity = new();
    }
}
