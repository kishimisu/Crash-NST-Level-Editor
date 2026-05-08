namespace Alchemy
{
    [ObjectAttr(nst: 144, ctr: 136, align: 4, metaType: typeof(CVscComponentData))]
    public class common_MackCinematicPlayerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Edc_Info = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Cutscene_Data = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Zone_Info = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Fade_Sequence_Preset_Data_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Checkpoint = new();
        [FieldAttr(nst: 80, ctr: 72)] public bool _Bool_0x50;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Fade_Sequence_Preset_Data_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Game_Sound_Music_Settings_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Game_Sound_Music_Settings_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public float _Float;
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 128, ctr: 120)] public bool _Bool_0x80;
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Fade_Out_Preset_Data = new();
    }
}
