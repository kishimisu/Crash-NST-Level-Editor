namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class EAP_MoleEventData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Vfx_Effect_0x30 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Vfx_Effect_id_0f05rtkc001 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Bolt_Point_0x40 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Bolt_Point_0x48 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Bolt_Point_id_vcszxc3j001 = new();
    }
}
