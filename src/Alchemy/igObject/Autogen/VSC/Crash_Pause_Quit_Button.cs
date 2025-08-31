namespace Alchemy
{
    // VSC object extracted from: Crash_Pause_Quit_Button.igz

    [ObjectAttr(128, metaType: typeof(igGuiVscBehavior))]
    public class Crash_Pause_Quit_Button : igGuiVscBehavior
    {
        [FieldAttr(40)] public int _InternalStore__internalCounter;
        [FieldAttr(48)] public igHandleMetaField _TitleScreenZoneInfo = new();
        [FieldAttr(56)] public igHandleMetaField _LoadMapFadeOut = new();
        [FieldAttr(64)] public igHandleMetaField _localCurrZoneInfo = new();
        [FieldAttr(72)] public bool _isLoadBackToHub;
        [FieldAttr(80)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(88)] public igObject? _Player_Variable_Node = new();
        [FieldAttr(96)] public igHandleMetaField _Zone_Info_0x60 = new();
        [FieldAttr(104)] public igHandleMetaField _Zone_Info_0x68 = new();
        [FieldAttr(112)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(120)] public igHandleMetaField _Sound = new();
    }
}
