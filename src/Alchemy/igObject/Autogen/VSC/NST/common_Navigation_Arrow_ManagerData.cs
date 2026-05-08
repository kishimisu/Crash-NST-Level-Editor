namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Navigation_Arrow_ManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Waypoint_List = new();
        [FieldAttr(nst: 48, ctr: 40)] public string? _String = null;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float;
    }
}
