namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_Save_Load_Root : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Animation_Tag = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Gui_Placeable = new();
    }
}
