namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_Racer_HUD_JumpBar : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igObject? _InternalStore_updateNodeUpdater_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(nst: 72, ctr: 64)] public string? _String = null;
        [FieldAttr(nst: 80, ctr: 72)] public igVec4ucMetaField _Color = new();
        [FieldAttr(nst: 84, ctr: 76)] public float _Float_0x4c;
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x50;
        [FieldAttr(nst: 96, ctr: 88)] public igObject? _InternalStore__timer = new();
        [FieldAttr(nst: 104, ctr: 96)] public igObject? _InternalStore_updateNodeUpdater_0x60 = new();
        [FieldAttr(nst: 112, ctr: 104)] public float _Float_0x68;
        [FieldAttr(nst: 116, ctr: 108)] public float _Float_0x6c;
        [FieldAttr(nst: 120, ctr: 112)] public float _Float_0x70;
        [FieldAttr(nst: 124, ctr: 116)] public EOctaneBoostBarType _E_Octane_Boost_Bar_Type;
    }
}
