namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_MainMenu_RaceModeSettings_Movie : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public float _Float;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(nst: 72, ctr: 64)] public igObject? _InternalStore_sliderData = new();
        [FieldAttr(nst: 80, ctr: 72)] public EOctaneRaceModes _E_Octane_Race_Modes;
        [FieldAttr(nst: 84, ctr: 76)] public bool _Bool;
    }
}
