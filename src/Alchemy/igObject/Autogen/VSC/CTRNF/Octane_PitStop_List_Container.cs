namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_PitStop_List_Container : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_Placeable_0x28 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Placeable_0x30 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igObject? _Gui_List_Item_List = new();
        [FieldAttr(nst: 72, ctr: 64)] public ESignal _Gui_Input_Signal;
        [FieldAttr(nst: 76, ctr: 68)] public bool _Bool;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Gui_List_Item = new();
        [FieldAttr(nst: 88, ctr: 80)] public EController _Gui_Input_Controller;
    }
}
