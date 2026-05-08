namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_PowerUpCrateData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect_0x20 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public EThemeSFXType _E_Theme_SFX_Type_0x30;
        [FieldAttr(nst: 60, ctr: 52)] public EThemeSFXType _E_Theme_SFX_Type_0x34;
    }
}
