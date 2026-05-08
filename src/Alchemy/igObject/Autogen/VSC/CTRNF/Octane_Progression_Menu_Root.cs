namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_Progression_Menu_Root : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public int _InternalStore__internalCounter;
        [FieldAttr(nst: 56, ctr: 48)] public igObject? _InternalStore__timer = new();
        [FieldAttr(nst: 64, ctr: 56)] public igObject? _InternalStore__gate = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Gui_Placeable_0x40 = new();
        [FieldAttr(nst: 80, ctr: 72)] public int _Int;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Gui_Animation_Tag_0x50 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Gui_Animation_Tag_0x58 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Gui_Placeable_0x60 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Material = new();
    }
}
