namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_Progression_Menu_AreaList : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_List_Item = new();
        [FieldAttr(nst: 56, ctr: 48)] public ESignal _Gui_Input_Signal;
        [FieldAttr(nst: 60, ctr: 52)] public EController _Gui_Input_Controller;
        [FieldAttr(nst: 64, ctr: 56)] public igObject? _Gui_List_Item_List = new();
    }
}
