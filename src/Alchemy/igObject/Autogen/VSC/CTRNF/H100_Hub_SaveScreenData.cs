namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class H100_Hub_SaveScreenData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
    }
}
