namespace Alchemy
{
    [ObjectAttr(nst: 200, ctr: 192, align: 4, metaType: typeof(CVscComponentData))]
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

        [FieldAttr(nst: 40, ctr: 32)] public bool _IsAkuAkuIlluminated;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _IsIlluminatedGameVar = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Game_Bool_Variable_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool_0x40;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public bool _Bool_0x50;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Game_Bool_Variable_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public bool _Bool_0x60;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _spawnEntity = new();
        [FieldAttr(nst: 112, ctr: 104)] public EZoneCollectibleType _E_Zone_Collectible_Type;
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Entity_0x78 = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _CrateCount = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _CrateTotal = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Fade_Out_Preset_Data = new();
        [FieldAttr(nst: 152, ctr: 144)] public ENewEnum9_id_5y039ngg _NewEnum9_id_5y039ngg;
        [FieldAttr(nst: 156, ctr: 148)] public ENewEnum9_id_i7ih7bke _NewEnum9_id_i7ih7bke;
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _Game_Bool_Variable_0xa0 = new();
        [FieldAttr(nst: 168, ctr: 160)] public bool _Bool_0xa8;
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _Game_Float_Variable = new();
        [FieldAttr(nst: 184, ctr: 176)] public float _Float_0xb8;
        [FieldAttr(nst: 188, ctr: 180)] public float _Float_0xbc;
        [FieldAttr(nst: 192, ctr: 184)] public float _Float_0xc0;
        [FieldAttr(nst: 196, ctr: 188)] public float _Float_0xc4;
    }
}
