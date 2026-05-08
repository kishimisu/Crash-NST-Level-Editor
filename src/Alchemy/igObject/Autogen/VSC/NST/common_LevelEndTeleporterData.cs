namespace Alchemy
{
    [ObjectAttr(nst: 240, ctr: 232, align: 4, metaType: typeof(CVscComponentData))]
    public class common_LevelEndTeleporterData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _IsBonusRoundTeleporter;
        [FieldAttr(nst: 44, ctr: 36)] public EigEaseType _MoveCrashCenterEaseType;
        [FieldAttr(nst: 48, ctr: 40)] public float _MoveCrashCenterTime;
        [FieldAttr(nst: 52, ctr: 44)] public float _MoveCrashCenterEaseRatioIn;
        [FieldAttr(nst: 56, ctr: 48)] public float _MoveCrashCenterEaseRatioOut;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _VfxTeleporterData = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Game_Bool_Variable_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public string? _BehaviorEventCrashTeleportOutStart = null;
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 104, ctr: 96)] public bool _Bool_0x68;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _GemCollected = new();
        [FieldAttr(nst: 120, ctr: 112)] public string? _String_0x78 = null;
        [FieldAttr(nst: 128, ctr: 120)] public string? _String_0x80 = null;
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Game_Int_Variable = new();
        [FieldAttr(nst: 144, ctr: 136)] public bool _Bool_0x90;
        [FieldAttr(nst: 148, ctr: 140)] public float _Float_0x94;
        [FieldAttr(nst: 152, ctr: 144)] public float _Float_0x98;
        [FieldAttr(nst: 156, ctr: 148)] public ECrashSecretZones _E_Crash_Secret_Zones;
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _Game_Bool_Variable_0xa0 = new();
        [FieldAttr(nst: 168, ctr: 160)] public float _Float_0xa8;
        [FieldAttr(nst: 176, ctr: 168)] public string? _String_0xb0 = null;
        [FieldAttr(nst: 184, ctr: 176)] public float _Float_0xb8;
        [FieldAttr(nst: 192, ctr: 184)] public igHandleMetaField _Vfx_Effect_0xc0 = new();
        [FieldAttr(nst: 200, ctr: 192)] public string? _String_0xc8 = null;
        [FieldAttr(nst: 208, ctr: 200)] public float _Float_0xd0;
        [FieldAttr(nst: 212, ctr: 204)] public float _Float_0xd4;
        [FieldAttr(nst: 216, ctr: 208)] public igHandleMetaField _Vfx_Effect_0xd8 = new();
        [FieldAttr(nst: 224, ctr: 216)] public bool _Bool_0xe0;
        [FieldAttr(nst: 228, ctr: 220)] public float _Float_0xe4;
        [FieldAttr(nst: 232, ctr: 224)] public igHandleMetaField _PlayerDied = new();
    }
}
