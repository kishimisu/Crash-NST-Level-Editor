namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class BossRipperRooC2_AiBossManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Waypoint = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float_0x3c;
        [FieldAttr(nst: 64, ctr: 56)] public EigEaseType _Ease_Type_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float_0x44;
        [FieldAttr(nst: 72, ctr: 64)] public float _Float_0x48;
        [FieldAttr(nst: 76, ctr: 68)] public float _Float_0x4c;
        [FieldAttr(nst: 80, ctr: 72)] public EigEaseType _Ease_Type_0x50;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Entity_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Bolt_Point_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Entity_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Bolt_Point_0x78 = new();
    }
}
