namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
    public class L330_RingsOfPower_Race_ManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Fade_Out_Preset_Data = new();
        [FieldAttr(nst: 80, ctr: 72)] public string? _String = null;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Debug_Update_Channel = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 112, ctr: 104)] public EZoneCollectibleType _E_Zone_Collectible_Type;
    }
}
