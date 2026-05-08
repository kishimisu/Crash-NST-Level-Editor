namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class common_Crash_Boss_Spot_Hud_Root : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Animation_Tag = new();
        [FieldAttr(nst: 64, ctr: 56)] public string? _String = null;
    }
}
