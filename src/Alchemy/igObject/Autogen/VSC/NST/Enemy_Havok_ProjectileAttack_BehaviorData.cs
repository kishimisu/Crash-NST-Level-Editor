namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Havok_ProjectileAttack_BehaviorData : CVscComponentData
    {
        public enum ENewEnum16_id_xvpkfmma
        {
            AtPlayer = 0,
            AtReferenceTargets = 1,
            AtPositionWithinRange = 2,
            NoTarget = 3,
        }

        [FieldAttr(nst: 40, ctr: 32)] public ENewEnum16_id_xvpkfmma _NewEnum16_id_xvpkfmma;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Projectile_Spawn_Data = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity_Data = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float_0x44;
        [FieldAttr(nst: 72, ctr: 64)] public float _Float_0x48;
        [FieldAttr(nst: 76, ctr: 68)] public float _Float_0x4c;
        [FieldAttr(nst: 80, ctr: 72)] public bool _Bool;
        [FieldAttr(nst: 84, ctr: 76)] public float _Float_0x54;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Bolt_Point_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Bolt_Point_0x78 = new();
    }
}
