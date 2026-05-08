namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class ShowPowerUpQuantity : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Gui_Placeable = new();
        [FieldAttr(nst: 56, ctr: 48)] public int _Int;
    }
}
