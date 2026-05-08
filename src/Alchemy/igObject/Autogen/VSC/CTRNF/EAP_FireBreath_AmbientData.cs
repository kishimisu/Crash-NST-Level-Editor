namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class EAP_FireBreath_AmbientData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Sound_0x30 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Sound_0x38 = new();
    }
}
