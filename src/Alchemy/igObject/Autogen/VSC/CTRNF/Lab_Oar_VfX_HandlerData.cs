namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Lab_Oar_VfX_HandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity_0x30 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Sound = new();
    }
}
