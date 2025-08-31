namespace Alchemy
{
    // VSC object extracted from: L330_RingsOfPower_Race_Manager.igz

    [ObjectAttr(120, metaType: typeof(CVscComponentData))]
    public class L330_RingsOfPower_Race_ManagerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity = new();
        [FieldAttr(48)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(56)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(64)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(72)] public igHandleMetaField _Fade_Out_Preset_Data = new();
        [FieldAttr(80)] public string? _String = null;
        [FieldAttr(88)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(96)] public igHandleMetaField _Debug_Update_Channel = new();
        [FieldAttr(104)] public igHandleMetaField _Sound = new();
        [FieldAttr(112)] public EZoneCollectibleType _E_Zone_Collectible_Type;
    }
}
