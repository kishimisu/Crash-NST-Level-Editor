namespace Alchemy
{
    // VSC object extracted from: C3_HubTalkingHeadsCutscenePlayer.igz

    [ObjectAttr(240, metaType: typeof(CVscComponentData))]
    public class C3_HubTalkingHeadsCutscenePlayerData : CVscComponentData
    {
        public enum ENewEnum20_id_9ip97ee5
        {
            StoryProgression = 0,
            CrystalsCollected = 1,
            CrystalFail = 2,
            TimeTrialIntro = 3,
        }

        public enum ENewEnum20_id_2pwobb9e
        {
            AkuAku = 0,
            TinyTiger = 1,
            Dingodile = 2,
            NTropy = 3,
            NGin = 4,
            Cortex = 5,
        }

        [FieldAttr(40)] public ENewEnum20_id_9ip97ee5 _NewEnum20_id_9ip97ee5;
        [FieldAttr(44)] public int _Int;
        [FieldAttr(48)] public bool _Bool;
        [FieldAttr(52)] public ENewEnum20_id_2pwobb9e _NewEnum20_id_2pwobb9e;
        [FieldAttr(56)] public string? _String = null;
        [FieldAttr(64)] public igHandleMetaField _Localized_Line = new();
        [FieldAttr(72)] public float _Float;
        [FieldAttr(80)] public igHandleMetaField _Entity_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Cutscene_Data = new();
        [FieldAttr(96)] public igHandleMetaField _Edc_Info = new();
        [FieldAttr(104)] public igHandleMetaField _Fade_Sequence_Preset_Data_0x68 = new();
        [FieldAttr(112)] public igHandleMetaField _Fade_Sequence_Preset_Data_0x70 = new();
        [FieldAttr(120)] public igHandleMetaField _Fade_Sequence_Preset_Data_0x78 = new();
        [FieldAttr(128)] public igHandleMetaField _Fade_Sequence_Preset_Data_0x80 = new();
        [FieldAttr(136)] public igHandleMetaField _Fade_Sequence_Preset_Data_0x88 = new();
        [FieldAttr(144)] public igHandleMetaField _Entity_0x90 = new();
        [FieldAttr(152)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(160)] public igHandleMetaField _Entity_0xa0 = new();
        [FieldAttr(168)] public igHandleMetaField _Entity_0xa8 = new();
        [FieldAttr(176)] public igHandleMetaField _Entity_0xb0 = new();
        [FieldAttr(184)] public igHandleMetaField _Entity_0xb8 = new();
        [FieldAttr(192)] public igHandleMetaField _Entity_0xc0 = new();
        [FieldAttr(200)] public igHandleMetaField _Entity_0xc8 = new();
        [FieldAttr(208)] public igHandleMetaField _Game_Int_Variable = new();
        [FieldAttr(216)] public igHandleMetaField _Sound_0xd8 = new();
        [FieldAttr(224)] public igHandleMetaField _Sound_0xe0 = new();
        [FieldAttr(232)] public igHandleMetaField _Checkpoint = new();
    }
}
