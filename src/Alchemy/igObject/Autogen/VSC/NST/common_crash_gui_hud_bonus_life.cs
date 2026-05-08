namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class common_crash_gui_hud_bonus_life : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Spawned_Vfx_EffectVariable = new();
        [FieldAttr(nst: 48, ctr: 40)] public int _Int;
        [FieldAttr(nst: 56, ctr: 48)] public igObject? _InternalStore_sliderData_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float_0x44;
        [FieldAttr(nst: 72, ctr: 64)] public igObject? _InternalStore_sliderData_0x48 = new();
    }
}
