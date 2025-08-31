namespace Alchemy
{
    // VSC object extracted from: common_MackCinematicPlayer.igz

    [ObjectAttr(144, metaType: typeof(CVscComponentData))]
    public class common_MackCinematicPlayerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Edc_Info = new();
        [FieldAttr(48)] public igHandleMetaField _Cutscene_Data = new();
        [FieldAttr(56)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(64)] public igHandleMetaField _Fade_Sequence_Preset_Data_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Checkpoint = new();
        [FieldAttr(80)] public bool _Bool_0x50;
        [FieldAttr(88)] public igHandleMetaField _Fade_Sequence_Preset_Data_0x58 = new();
        [FieldAttr(96)] public igHandleMetaField _Game_Sound_Music_Settings_0x60 = new();
        [FieldAttr(104)] public igHandleMetaField _Game_Sound_Music_Settings_0x68 = new();
        [FieldAttr(112)] public float _Float;
        [FieldAttr(120)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(128)] public bool _Bool_0x80;
        [FieldAttr(136)] public igHandleMetaField _Fade_Out_Preset_Data = new();
    }
}
