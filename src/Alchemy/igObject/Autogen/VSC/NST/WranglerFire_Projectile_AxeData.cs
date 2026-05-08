namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class WranglerFire_Projectile_AxeData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _BoltPointVariable_id_6eonfll1_variable = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _BoltPointVariable_id_cc2mfhc5_variable = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _AxeDestroyDistance;
        [FieldAttr(nst: 60, ctr: 52)] public float _AxeReturnTime;
        [FieldAttr(nst: 64, ctr: 56)] public float _AxeDestroyCheckUpdateTime;
        [FieldAttr(nst: 68, ctr: 60)] public float _AxeReturnTimeLimit;
        [FieldAttr(nst: 72, ctr: 64)] public string? _AxeCaught = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _AxeSpawned = null;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Projectile_AxeThrow_Vfx_Red = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Attack_AxeThrow_Vfx_Blue = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Attack_AxeThrow_Vfx_Red = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Projectile_AxeThrow_Vfx_Blue = new();
    }
}
