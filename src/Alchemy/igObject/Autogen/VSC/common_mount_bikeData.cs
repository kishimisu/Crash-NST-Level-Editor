namespace Alchemy
{
    // VSC object extracted from: common_mount_bike.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class common_mount_bikeData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(48)] public igHandleMetaField _Entity_Data = new();
        [FieldAttr(56)] public bool _Bool;
        [FieldAttr(64)] public igHandleMetaField _Bolt_Point = new();
    }
}
