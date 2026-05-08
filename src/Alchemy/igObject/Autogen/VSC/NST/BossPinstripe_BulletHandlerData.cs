namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class BossPinstripe_BulletHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_Tag = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Vfx_Effect_0x38 = new();
    }
}
