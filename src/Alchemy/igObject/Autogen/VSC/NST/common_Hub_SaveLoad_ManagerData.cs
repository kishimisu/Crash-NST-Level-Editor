namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Hub_SaveLoad_ManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Localized_String = new();
    }
}
