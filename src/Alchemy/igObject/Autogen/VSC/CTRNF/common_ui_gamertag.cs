namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class common_ui_gamertag : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(nst: 56, ctr: 48)] public string? _String = null;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Localized_String = new();
        [FieldAttr(nst: 72, ctr: 64)] public igObject? _InternalStore_updateNodeUpdater = new();
    }
}
