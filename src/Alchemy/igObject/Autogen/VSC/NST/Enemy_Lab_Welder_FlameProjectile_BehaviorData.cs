namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Lab_Welder_FlameProjectile_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_Data = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Bolt_Point_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 72, ctr: 64)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 84, ctr: 76)] public float _Float_0x54;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Bolt_Point_0x60 = new();
    }
}
