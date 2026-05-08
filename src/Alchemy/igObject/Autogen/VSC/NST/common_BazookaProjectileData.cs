namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class common_BazookaProjectileData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_Tag_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Damage_Data = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Vfx_Effect_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Vfx_Effect_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Query_Filter = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Entity_Tag_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Entity_Tag_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Entity_Tag_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Entity_Tag_0x78 = new();
    }
}
