namespace Alchemy
{
    // VSC object extracted from: common_Hub_SaveLoad_Manager.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_Hub_SaveLoad_ManagerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(48)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(56)] public igHandleMetaField _Localized_String = new();
    }
}
