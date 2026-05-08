namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class common_ui_backgroundUpdater : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_Placeable_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Gui_Placeable_0x38 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igObject? _InternalStore__timer_0x40 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igObject? _InternalStore_sliderData = new();
        [FieldAttr(nst: 88, ctr: 80)] public igObject? _InternalStore__timer_0x50 = new();
        [FieldAttr(nst: 96, ctr: 88)] public EOctaneRaceModes _E_Octane_Race_Modes;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Material = new();
        [FieldAttr(nst: 112, ctr: 104)] public igObject? _InternalStore__timer_0x68 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igVec4ucMetaField _Color = new();
    }
}
