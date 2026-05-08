namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_Lobby_Timer_Root : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_Animation_Tag_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Animation_Tag_0x30 = new();
        [FieldAttr(nst: 64, ctr: 56)] public ECGuiLobbyTimerState _Gui_Lobby_Timer_State;
    }
}
