namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_Racer_HUD_Old_Boost_Bar_Positioning : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public EOctaneBoostBarType _E_Octane_Boost_Bar_Type;
        [FieldAttr(nst: 56, ctr: 48)] public igObject? _InternalStore_counter = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Gui_Placeable_0x38 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Gui_Placeable_0x40 = new();
    }
}
