namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class PauseMenu_2015_Quit_Button : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _HubMapZoneInfo = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _ButtonQuitGameText = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _String_List = new();
        [FieldAttr(nst: 64, ctr: 56)] public string? _String = null;
        [FieldAttr(nst: 72, ctr: 64)] public int _InternalStore__internalCounter;
        [FieldAttr(nst: 76, ctr: 68)] public bool _Bool;
        [FieldAttr(nst: 80, ctr: 72)] public igObject? _Player_Variable_Node = new();
        [FieldAttr(nst: 88, ctr: 80)] public bool _isLoadBackToHub;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _TitleScreenZoneInfo = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _LoadMapFadeOut = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _AnimationIdle = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _localCurrZoneInfo = new();
    }
}
