namespace Alchemy
{
    // VSC object extracted from: C2_HubTalkingHeadsCutscenePlayer.igz

    [ObjectAttr(336, metaType: typeof(CVscComponentData))]
    public class C2_HubTalkingHeadsCutscenePlayerData : CVscComponentData
    {
        public enum ENewEnum16_id_v38q14g9
        {
            Cortex = 0,
            Coco = 1,
            NBrio = 2,
        }

        public enum ETalkingHeadTypes
        {
            Cortex = 0,
            Coco = 1,
            NBrio = 2,
        }

        public enum ENewEnum17_id_o6pds769
        {
            DebugPlayOnly = 0,
            Progression = 1,
            CrystalsCollected = 2,
            CrystalFail = 3,
            AllGemsCollected = 4,
            GemsIntro = 5,
            ProgressionPostBoss = 6,
        }

        [FieldAttr(40)] public igHandleMetaField _Cutscene_Data = new();
        [FieldAttr(48)] public igHandleMetaField _Designer_Cutscene_Info = new();
        [FieldAttr(56)] public ENewEnum16_id_v38q14g9 _NewEnum16_id_v38q14g9;
        [FieldAttr(60)] public ETalkingHeadTypes _TalkingHeadTypes;
        [FieldAttr(64)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Entity_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Entity_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Entity_0x58 = new();
        [FieldAttr(96)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(104)] public igHandleMetaField _Localized_Line_0x68 = new();
        [FieldAttr(112)] public string? _String_0x70 = null;
        [FieldAttr(120)] public bool _Bool_0x78;
        [FieldAttr(128)] public igHandleMetaField _Localized_Line_0x80 = new();
        [FieldAttr(136)] public string? _String_0x88 = null;
        [FieldAttr(144)] public ENewEnum17_id_o6pds769 _NewEnum17_id_o6pds769;
        [FieldAttr(148)] public int _Int;
        [FieldAttr(152)] public float _Float_0x98;
        [FieldAttr(156)] public float _Float_0x9c;
        [FieldAttr(160)] public igHandleMetaField _Game_Int_Variable = new();
        [FieldAttr(168)] public igHandleMetaField _Query_Filter = new();
        [FieldAttr(176)] public float _Float_0xb0;
        [FieldAttr(180)] public float _Float_0xb4;
        [FieldAttr(184)] public EigEaseType _Ease_Type;
        [FieldAttr(188)] public float _Float_0xbc;
        [FieldAttr(192)] public float _Float_0xc0;
        [FieldAttr(196)] public float _Float_0xc4;
        [FieldAttr(200)] public float _Float_0xc8;
        [FieldAttr(204)] public float _Float_0xcc;
        [FieldAttr(208)] public float _Float_0xd0;
        [FieldAttr(212)] public float _Float_0xd4;
        [FieldAttr(216)] public igHandleMetaField _Entity_0xd8 = new();
        [FieldAttr(224)] public igHandleMetaField _Game_Sound_Music_Settings_0xe0 = new();
        [FieldAttr(232)] public igHandleMetaField _Game_Sound_Music_Settings_0xe8 = new();
        [FieldAttr(240)] public igHandleMetaField _Game_Sound_Music_Settings_0xf0 = new();
        [FieldAttr(248)] public igHandleMetaField _Game_Sound_Music_Settings_0xf8 = new();
        [FieldAttr(256)] public bool _Bool_0x100;
        [FieldAttr(264)] public igHandleMetaField _Localized_Line_0x108 = new();
        [FieldAttr(272)] public string? _String_0x110 = null;
        [FieldAttr(280)] public float _Float_0x118;
        [FieldAttr(288)] public igHandleMetaField _Sound_0x120 = new();
        [FieldAttr(296)] public igHandleMetaField _Sound_0x128 = new();
        [FieldAttr(304)] public igHandleMetaField _Sound_0x130 = new();
        [FieldAttr(312)] public igHandleMetaField _Sound_0x138 = new();
        [FieldAttr(320)] public igHandleMetaField _Sound_0x140 = new();
        [FieldAttr(328)] public igHandleMetaField _Checkpoint = new();
    }
}
