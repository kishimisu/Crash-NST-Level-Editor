namespace Alchemy
{
    // VSC object extracted from: BlasterTech_DustCloudComponent_c.igz

    [ObjectAttr(88, metaType: typeof(CVscComponentData))]
    public class BlasterTech_DustCloudComponentData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Unnamed_BoltPoint = new();
        [FieldAttr(48)] public igHandleMetaField _DustCloudBuff = new();
        [FieldAttr(56)] public float _Lifetime;
        [FieldAttr(64)] public igHandleMetaField _DustBuffVfx = new();
        [FieldAttr(72)] public igHandleMetaField _AuthorityCloudVfx = new();
        [FieldAttr(80)] public igHandleMetaField _NonAuthorityCloudVfx = new();
    }
}
