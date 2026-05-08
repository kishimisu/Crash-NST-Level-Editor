namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_Help_Hints_Menu_HintsList : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public EController _Gui_Input_Controller;
        [FieldAttr(nst: 56, ctr: 48)] public igObject? _Gui_List_Item_List = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Gui_List_Item = new();
        [FieldAttr(nst: 72, ctr: 64)] public ESignal _Gui_Input_Signal;
    }
}
