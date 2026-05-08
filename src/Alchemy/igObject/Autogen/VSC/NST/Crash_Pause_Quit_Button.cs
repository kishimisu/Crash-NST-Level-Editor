namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Crash_Pause_Quit_Button : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public int _InternalStore__internalCounter;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _TitleScreenZoneInfo = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _LoadMapFadeOut = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _localCurrZoneInfo = new();
        [FieldAttr(nst: 72, ctr: 64)] public bool _isLoadBackToHub;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 88, ctr: 80)] public igObject? _Player_Variable_Node = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Zone_Info_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Zone_Info_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Sound = new();
    }
}
