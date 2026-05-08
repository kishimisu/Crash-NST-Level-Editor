namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class BlasterTech_DustCloudComponentData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Unnamed_BoltPoint = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _DustCloudBuff = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Lifetime;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _DustBuffVfx = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _AuthorityCloudVfx = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _NonAuthorityCloudVfx = new();
    }
}
