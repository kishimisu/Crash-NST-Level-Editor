namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class BossRipperRoo_AiBossManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float_0x3c;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _Float_0x48;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Damage_Data = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(nst: 96, ctr: 88)] public EigEaseType _Ease_Type;
        [FieldAttr(nst: 100, ctr: 92)] public EigEaseMode _Ease_Mode;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Vfx_Effect_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Bolt_Point = new();
    }
}
