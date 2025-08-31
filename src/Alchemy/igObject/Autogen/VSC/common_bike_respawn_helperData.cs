namespace Alchemy
{
    // VSC object extracted from: common_bike_respawn_helper.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_bike_respawn_helperData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(48)] public igHandleMetaField _Entity = new();
        [FieldAttr(56)] public igHandleMetaField _Bolt_Point = new();
    }
}
