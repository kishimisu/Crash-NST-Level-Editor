namespace Alchemy
{
    [ObjectAttr(nst: 168, ctr: 160, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_CupSelect_ListButton : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public string? _String = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Gui_Animation_Tag_0x40 = new();
        [FieldAttr(nst: 80, ctr: 72)] public EOctaneRaceModes _E_Octane_Race_Modes;
        [FieldAttr(nst: 88, ctr: 80)] public igObject? _InternalStore__timer = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Gui_Placeable_0x58 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Gui_Animation_Tag_0x60 = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Gui_Placeable_0x68 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igObject? _InternalStore_updateNodeUpdater_0x70 = new();
        [FieldAttr(nst: 128, ctr: 120)] public igObject? _InternalStore_updateNodeUpdater_0x78 = new();
        [FieldAttr(nst: 136, ctr: 128)] public ESignal _Gui_Input_Signal;
        [FieldAttr(nst: 140, ctr: 132)] public EController _Gui_Input_Controller;
        [FieldAttr(nst: 144, ctr: 136)] public igObject? _Gui_List_Item_List = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Gui_List_Item = new();
        [FieldAttr(nst: 160, ctr: 152)] public float _Float_0x98;
        [FieldAttr(nst: 164, ctr: 156)] public float _Float_0x9c;
    }
}
