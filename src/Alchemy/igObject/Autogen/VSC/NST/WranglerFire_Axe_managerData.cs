namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class WranglerFire_Axe_managerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _ChargeLoop_BehaviorState = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Attack_AxeThrow_Partial = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _ThrownAxe_EntityData = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Enable_B_Attack = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Disable_B_Attack = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _ThrownAxe_ProjectileSpawnData = new();
    }
}
