namespace Alchemy
{
    // VSC object extracted from: common_Chase_Fence_c.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_Chase_FenceData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _RequiredTag = new();
        [FieldAttr(48)] public igHandleMetaField _HitSound = new();
        [FieldAttr(56)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(64)] public igHandleMetaField _Vfx_Effect_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Vfx_Effect_0x48 = new();
    }
}
