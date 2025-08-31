namespace Alchemy
{
    // VSC object extracted from: common_LevelManagerBossFight_c.igz

    [ObjectAttr(200, metaType: typeof(CVscComponentData))]
    public class common_LevelManagerBossFightData : CVscComponentData
    {
        public enum ENewEnum22_id_3ksuomi4
        {
            C1PapuPapu = 0,
            C1RipperRoo = 1,
            C1KoalaKong = 2,
            C1PinstripePotoroo = 3,
            C1NBrio = 4,
            C1NCortex = 5,
            C2RipperRoo = 6,
            C2KomodoBrothers = 7,
            C2TinyTiger = 8,
            C2NGin = 9,
            C2NCortex = 10,
            C3TinyTiger = 11,
            C3Dingodile = 12,
            C3NTropy = 13,
            C3NGin = 14,
            C3NCortex = 15,
        }

        public enum ENewEnum9_id_eljgq18d
        {
            Basic = 0,
            RayCast = 1,
            RayCastCrashTwoPlus = 2,
        }

        public enum ENewEnum9_id_o42lk9ct
        {
            LightShadow = 0,
            MediumShadow = 1,
            DarkShadow = 2,
        }

        [FieldAttr(40)] public bool _Bool_0x28;
        [FieldAttr(48)] public igHandleMetaField _Entity_0x30 = new();
        [FieldAttr(56)] public float _Float_0x38;
        [FieldAttr(60)] public bool _Bool_0x3c;
        [FieldAttr(61)] public bool _Bool_0x3d;
        [FieldAttr(64)] public igHandleMetaField _Zone_Info_0x40 = new();
        [FieldAttr(72)] public igHandleMetaField _Zone_Info_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Zone_Info_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Zone_Info_0x58 = new();
        [FieldAttr(96)] public int _Int;
        [FieldAttr(104)] public igHandleMetaField _Zone_Info_0x68 = new();
        [FieldAttr(112)] public igHandleMetaField _Entity_0x70 = new();
        [FieldAttr(120)] public igHandleMetaField _Game_Bool_Variable_0x78 = new();
        [FieldAttr(128)] public igHandleMetaField _Entity_0x80 = new();
        [FieldAttr(136)] public igHandleMetaField _Game_Bool_Variable_0x88 = new();
        [FieldAttr(144)] public bool _Bool_0x90;
        [FieldAttr(148)] public ENewEnum22_id_3ksuomi4 _NewEnum22_id_3ksuomi4;
        [FieldAttr(152)] public string? _BehaviorEventCrashVictory = null;
        [FieldAttr(160)] public bool _Bool_0xa0;
        [FieldAttr(168)] public igHandleMetaField _Entity_0xa8 = new();
        [FieldAttr(176)] public igHandleMetaField _Fade_Out_Preset_Data = new();
        [FieldAttr(184)] public ENewEnum9_id_eljgq18d _NewEnum9_id_eljgq18d;
        [FieldAttr(188)] public ENewEnum9_id_o42lk9ct _NewEnum9_id_o42lk9ct;
        [FieldAttr(192)] public bool _Bool_0xc0;
        [FieldAttr(196)] public float _Float_0xc4;
    }
}
