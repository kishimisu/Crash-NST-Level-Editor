namespace Alchemy
{
    // VSC object extracted from: common_Level_Manager_c.igz

    [ObjectAttr(200, metaType: typeof(CVscComponentData))]
    public class common_Level_ManagerData : CVscComponentData
    {
        public enum ENewEnum9_id_5y039ngg
        {
            LightShadow = 0,
            MediumShadow = 1,
            DarkShadow = 2,
        }

        public enum ENewEnum9_id_i7ih7bke
        {
            Basic = 0,
            RayCast = 1,
            RayCastCrashTwoPlus = 2,
        }

        [FieldAttr(40)] public bool _IsAkuAkuIlluminated;
        [FieldAttr(48)] public igHandleMetaField _IsIlluminatedGameVar = new();
        [FieldAttr(56)] public igHandleMetaField _Game_Bool_Variable_0x38 = new();
        [FieldAttr(64)] public bool _Bool_0x40;
        [FieldAttr(72)] public igHandleMetaField _Entity_0x48 = new();
        [FieldAttr(80)] public bool _Bool_0x50;
        [FieldAttr(88)] public igHandleMetaField _Game_Bool_Variable_0x58 = new();
        [FieldAttr(96)] public bool _Bool_0x60;
        [FieldAttr(104)] public igHandleMetaField _spawnEntity = new();
        [FieldAttr(112)] public EZoneCollectibleType _E_Zone_Collectible_Type;
        [FieldAttr(120)] public igHandleMetaField _Entity_0x78 = new();
        [FieldAttr(128)] public igHandleMetaField _CrateCount = new();
        [FieldAttr(136)] public igHandleMetaField _CrateTotal = new();
        [FieldAttr(144)] public igHandleMetaField _Fade_Out_Preset_Data = new();
        [FieldAttr(152)] public ENewEnum9_id_5y039ngg _NewEnum9_id_5y039ngg;
        [FieldAttr(156)] public ENewEnum9_id_i7ih7bke _NewEnum9_id_i7ih7bke;
        [FieldAttr(160)] public igHandleMetaField _Game_Bool_Variable_0xa0 = new();
        [FieldAttr(168)] public bool _Bool_0xa8;
        [FieldAttr(176)] public igHandleMetaField _Game_Float_Variable = new();
        [FieldAttr(184)] public float _Float_0xb8;
        [FieldAttr(188)] public float _Float_0xbc;
        [FieldAttr(192)] public float _Float_0xc0;
        [FieldAttr(196)] public float _Float_0xc4;
    }
}
