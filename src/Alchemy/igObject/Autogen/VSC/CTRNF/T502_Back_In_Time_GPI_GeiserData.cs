namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class T502_Back_In_Time_GPI_GeiserData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect_0x20 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Vfx_Effect_0x38 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Sound = new();
    }
}
