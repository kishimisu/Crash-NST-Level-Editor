namespace Alchemy
{
    // VSC object extracted from: WranglerFire_Projectile_Axe_c.igz

    [ObjectAttr(120, metaType: typeof(CVscComponentData))]
    public class WranglerFire_Projectile_AxeData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _BoltPointVariable_id_6eonfll1_variable = new();
        [FieldAttr(48)] public igHandleMetaField _BoltPointVariable_id_cc2mfhc5_variable = new();
        [FieldAttr(56)] public float _AxeDestroyDistance;
        [FieldAttr(60)] public float _AxeReturnTime;
        [FieldAttr(64)] public float _AxeDestroyCheckUpdateTime;
        [FieldAttr(68)] public float _AxeReturnTimeLimit;
        [FieldAttr(72)] public string? _AxeCaught = null;
        [FieldAttr(80)] public string? _AxeSpawned = null;
        [FieldAttr(88)] public igHandleMetaField _Projectile_AxeThrow_Vfx_Red = new();
        [FieldAttr(96)] public igHandleMetaField _Attack_AxeThrow_Vfx_Blue = new();
        [FieldAttr(104)] public igHandleMetaField _Attack_AxeThrow_Vfx_Red = new();
        [FieldAttr(112)] public igHandleMetaField _Projectile_AxeThrow_Vfx_Blue = new();
    }
}
