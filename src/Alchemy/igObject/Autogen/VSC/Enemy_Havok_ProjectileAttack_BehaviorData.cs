namespace Alchemy
{
    // VSC object extracted from: Enemy_Havok_ProjectileAttack_Behavior.igz

    [ObjectAttr(128, metaType: typeof(CVscComponentData))]
    public class Enemy_Havok_ProjectileAttack_BehaviorData : CVscComponentData
    {
        public enum ENewEnum16_id_xvpkfmma
        {
            AtPlayer = 0,
            AtReferenceTargets = 1,
            AtPositionWithinRange = 2,
            NoTarget = 3,
        }

        [FieldAttr(40)] public ENewEnum16_id_xvpkfmma _NewEnum16_id_xvpkfmma;
        [FieldAttr(48)] public igHandleMetaField _Projectile_Spawn_Data = new();
        [FieldAttr(56)] public igHandleMetaField _Entity_Data = new();
        [FieldAttr(64)] public float _Float_0x40;
        [FieldAttr(68)] public float _Float_0x44;
        [FieldAttr(72)] public float _Float_0x48;
        [FieldAttr(76)] public float _Float_0x4c;
        [FieldAttr(80)] public bool _Bool;
        [FieldAttr(84)] public float _Float_0x54;
        [FieldAttr(88)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(96)] public igHandleMetaField _Bolt_Point_0x60 = new();
        [FieldAttr(104)] public igHandleMetaField _Entity = new();
        [FieldAttr(112)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(120)] public igHandleMetaField _Bolt_Point_0x78 = new();
    }
}
