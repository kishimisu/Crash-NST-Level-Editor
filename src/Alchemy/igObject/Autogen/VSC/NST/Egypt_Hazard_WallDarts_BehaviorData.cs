namespace Alchemy
{
    [ObjectAttr(nst: 136, ctr: 128, align: 4, metaType: typeof(CVscComponentData))]
    public class Egypt_Hazard_WallDarts_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _ProjectileData = new();
        [FieldAttr(nst: 48, ctr: 40)] public igVec3fMetaField _Vec_3F_0x30 = new();
        [FieldAttr(nst: 60, ctr: 52)] public igVec3fMetaField _Vec_3F_0x3c = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Vfx_Effect_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 92, ctr: 84)] public float _Float_0x5c;
        [FieldAttr(nst: 96, ctr: 88)] public igVec3fMetaField _Vec_3F_0x60 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Vfx_Effect_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Bolt_Point_0x78 = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Bolt_Point_0x80 = new();
    }
}
