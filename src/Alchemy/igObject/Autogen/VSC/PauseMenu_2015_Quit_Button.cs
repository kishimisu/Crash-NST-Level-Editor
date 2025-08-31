namespace Alchemy
{
    // VSC object extracted from: PauseMenu_Quit_Button.igz

    [ObjectAttr(128, metaType: typeof(igGuiVscBehavior))]
    public class PauseMenu_2015_Quit_Button : igGuiVscBehavior
    {
        [FieldAttr(40)] public igHandleMetaField _HubMapZoneInfo = new();
        [FieldAttr(48)] public igHandleMetaField _ButtonQuitGameText = new();
        [FieldAttr(56)] public igHandleMetaField _String_List = new();
        [FieldAttr(64)] public string? _String = null;
        [FieldAttr(72)] public int _InternalStore__internalCounter;
        [FieldAttr(76)] public bool _Bool;
        [FieldAttr(80)] public igObject? _Player_Variable_Node = new();
        [FieldAttr(88)] public bool _isLoadBackToHub;
        [FieldAttr(96)] public igHandleMetaField _TitleScreenZoneInfo = new();
        [FieldAttr(104)] public igHandleMetaField _LoadMapFadeOut = new();
        [FieldAttr(112)] public igHandleMetaField _AnimationIdle = new();
        [FieldAttr(120)] public igHandleMetaField _localCurrZoneInfo = new();
    }
}
