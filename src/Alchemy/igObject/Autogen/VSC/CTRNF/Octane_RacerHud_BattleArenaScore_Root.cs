namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_RacerHud_BattleArenaScore_Root : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(nst: 56, ctr: 48)] public EOctaneRaceModes _E_Octane_Race_Modes;
        [FieldAttr(nst: 60, ctr: 52)] public bool _Bool_0x34;
        [FieldAttr(nst: 61, ctr: 53)] public bool _Bool_0x35;
    }
}
