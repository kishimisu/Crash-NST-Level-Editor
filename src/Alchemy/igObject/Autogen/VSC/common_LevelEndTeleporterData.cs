namespace Alchemy
{
    // VSC object extracted from: common_LevelEndTeleporter_c.igz

    [ObjectAttr(240, metaType: typeof(CVscComponentData))]
    public class common_LevelEndTeleporterData : CVscComponentData
    {
        [FieldAttr(40)] public bool _IsBonusRoundTeleporter;
        [FieldAttr(44)] public EigEaseType _MoveCrashCenterEaseType;
        [FieldAttr(48)] public float _MoveCrashCenterTime;
        [FieldAttr(52)] public float _MoveCrashCenterEaseRatioIn;
        [FieldAttr(56)] public float _MoveCrashCenterEaseRatioOut;
        [FieldAttr(64)] public igHandleMetaField _VfxTeleporterData = new();
        [FieldAttr(72)] public igHandleMetaField _Game_Bool_Variable_0x48 = new();
        [FieldAttr(80)] public string? _BehaviorEventCrashTeleportOutStart = null;
        [FieldAttr(88)] public float _Float_0x58;
        [FieldAttr(96)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(104)] public bool _Bool_0x68;
        [FieldAttr(112)] public igHandleMetaField _GemCollected = new();
        [FieldAttr(120)] public string? _String_0x78 = null;
        [FieldAttr(128)] public string? _String_0x80 = null;
        [FieldAttr(136)] public igHandleMetaField _Game_Int_Variable = new();
        [FieldAttr(144)] public bool _Bool_0x90;
        [FieldAttr(148)] public float _Float_0x94;
        [FieldAttr(152)] public float _Float_0x98;
        [FieldAttr(156)] public ECrashSecretZones _E_Crash_Secret_Zones;
        [FieldAttr(160)] public igHandleMetaField _Game_Bool_Variable_0xa0 = new();
        [FieldAttr(168)] public float _Float_0xa8;
        [FieldAttr(176)] public string? _String_0xb0 = null;
        [FieldAttr(184)] public float _Float_0xb8;
        [FieldAttr(192)] public igHandleMetaField _Vfx_Effect_0xc0 = new();
        [FieldAttr(200)] public string? _String_0xc8 = null;
        [FieldAttr(208)] public float _Float_0xd0;
        [FieldAttr(212)] public float _Float_0xd4;
        [FieldAttr(216)] public igHandleMetaField _Vfx_Effect_0xd8 = new();
        [FieldAttr(224)] public bool _Bool_0xe0;
        [FieldAttr(228)] public float _Float_0xe4;
        [FieldAttr(232)] public igHandleMetaField _PlayerDied = new();
    }
}
