namespace Alchemy
{
    // VSC object extracted from: common_Navigation_Arrow_Manager.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_Navigation_Arrow_ManagerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Waypoint_List = new();
        [FieldAttr(48)] public string? _String = null;
        [FieldAttr(56)] public float _Float;
    }
}
