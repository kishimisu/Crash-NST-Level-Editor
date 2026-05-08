namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Crash_Save_Load_Configure_Save_Slot : igGuiVscBehavior
    {
        [FieldAttr(nst: 40, ctr: 32)] public ECrashGame _E_Crash_Game;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_Animation_Tag_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Animation_Tag_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Gui_Animation_Tag_0x40 = new();
    }
}
