namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_teleport_entityData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Bool_0x20;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity_0x30 = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool_0x38;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Vfx_Effect = new();
    }
}
