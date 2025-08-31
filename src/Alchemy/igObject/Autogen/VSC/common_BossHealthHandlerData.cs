namespace Alchemy
{
    // VSC object extracted from: common_BossHealthHandler_c.igz

    [ObjectAttr(208, metaType: typeof(CVscComponentData))]
    public class common_BossHealthHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public bool _IsBehaviorEventTakeHitOverrideOn;
        [FieldAttr(41)] public bool _IsBounceEnable;
        [FieldAttr(42)] public bool _IsDamageOnAttackIdentifierOnly;
        [FieldAttr(43)] public bool _IsGuiBossHealthBarBottomScreen_0x2b;
        [FieldAttr(48)] public igHandleMetaField _BounceDamage = new();
        [FieldAttr(56)] public float _OnTakeHitImmuneTime;
        [FieldAttr(60)] public float _CrashBounceForwardSpeed;
        [FieldAttr(64)] public igHandleMetaField _GuiBossHealthBar = new();
        [FieldAttr(72)] public int _HitCount;
        [FieldAttr(80)] public igHandleMetaField _GuiBossName = new();
        [FieldAttr(88)] public igHandleMetaField _GuiBossPortrait = new();
        [FieldAttr(96)] public igHandleMetaField _GuiBossHealthBarMaterial_0x60 = new();
        [FieldAttr(104)] public string? _BehaviorEventTakeHitOverride = null;
        [FieldAttr(112)] public igHandleMetaField _DamageOnAttackIdentifierList = new();
        [FieldAttr(120)] public igHandleMetaField _String_List_0x78 = new();
        [FieldAttr(128)] public igHandleMetaField _String_List_0x80 = new();
        [FieldAttr(136)] public float _Float_0x88;
        [FieldAttr(140)] public bool _IsGuiBossHealthBarBottomScreen_0x8c;
        [FieldAttr(141)] public bool _Bool_0x8d;
        [FieldAttr(144)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(152)] public igHandleMetaField _GuiBossHealthBarMaterial_0x98 = new();
        [FieldAttr(160)] public igHandleMetaField _GuiBossHealthBarMaterial_0xa0 = new();
        [FieldAttr(168)] public igHandleMetaField _GuiBossHealthBarMaterial_0xa8 = new();
        [FieldAttr(176)] public bool _IsGuiBossHealthBarBottomScreen_0xb0;
        [FieldAttr(177)] public bool _IsGuiBossHealthBarBottomScreen_0xb1;
        [FieldAttr(178)] public bool _Bool_0xb2;
        [FieldAttr(180)] public float _Float_0xb4;
        [FieldAttr(184)] public float _Float_0xb8;
        [FieldAttr(188)] public float _Float_0xbc;
        [FieldAttr(192)] public EigEaseType _Ease_Type;
        [FieldAttr(196)] public bool _Bool_0xc4;
        [FieldAttr(200)] public string? _String = null;
    }
}
