namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_EndRaceMenu_Restart : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Gui_Animation_Tag_0x38 = new();
        [FieldAttr(nst: 72, ctr: 64)] public EOctaneRaceModes _E_Octane_Race_Modes;
        [FieldAttr(nst: 76, ctr: 68)] public bool _Bool;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Gui_Animation_Tag_0x48 = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Audio_Fade_Data = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Gui_Project_0x58 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Gui_Project_0x60 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Gui_Project_0x68 = new();
    }
}
