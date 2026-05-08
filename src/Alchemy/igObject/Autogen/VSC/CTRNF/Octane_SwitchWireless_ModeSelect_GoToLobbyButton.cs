namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_SwitchWireless_ModeSelect_GoToLobbyButton : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public int _Int;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(nst: 64, ctr: 56)] public EAsyncMatchmakingGameTypes _E_Async_Matchmaking_Game_Types;
    }
}
