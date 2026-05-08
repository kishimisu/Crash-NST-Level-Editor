namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_RacerHud_BattleArenaFlavourTitle_Root : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Animation_Tag = new();
        [FieldAttr(nst: 64, ctr: 56)] public string? _String = null;
        [FieldAttr(nst: 72, ctr: 64)] public igObject? _InternalStore__gate = new();
    }
}
