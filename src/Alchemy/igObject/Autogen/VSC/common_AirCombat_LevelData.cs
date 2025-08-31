namespace Alchemy
{
    // VSC object extracted from: common_AirCombat_Level.igz

    [ObjectAttr(152, metaType: typeof(CVscComponentData))]
    public class common_AirCombat_LevelData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(48)] public igHandleMetaField _Fade_Out_Preset_Data = new();
        [FieldAttr(56)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(64)] public string? _String = null;
        [FieldAttr(72)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(80)] public igHandleMetaField _Entity_Tag_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Entity_0x58 = new();
        [FieldAttr(96)] public float _Float;
        [FieldAttr(104)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(112)] public igHandleMetaField _Fade_In_Preset_Data = new();
        [FieldAttr(120)] public igHandleMetaField _Entity_Tag_0x78 = new();
        [FieldAttr(128)] public igHandleMetaField _Material_0x80 = new();
        [FieldAttr(136)] public igHandleMetaField _Material_0x88 = new();
        [FieldAttr(144)] public igHandleMetaField _Entity_0x90 = new();
    }
}
