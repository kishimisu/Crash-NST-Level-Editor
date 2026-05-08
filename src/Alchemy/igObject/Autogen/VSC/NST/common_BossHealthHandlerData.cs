namespace Alchemy
{
    [ObjectAttr(nst: 208, ctr: 200, align: 4, metaType: typeof(CVscComponentData))]
    public class common_BossHealthHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _IsBehaviorEventTakeHitOverrideOn;
        [FieldAttr(nst: 41, ctr: 33)] public bool _IsBounceEnable;
        [FieldAttr(nst: 42, ctr: 34)] public bool _IsDamageOnAttackIdentifierOnly;
        [FieldAttr(nst: 43, ctr: 35)] public bool _IsGuiBossHealthBarBottomScreen_0x2b;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _BounceDamage = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _OnTakeHitImmuneTime;
        [FieldAttr(nst: 60, ctr: 52)] public float _CrashBounceForwardSpeed;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _GuiBossHealthBar = new();
        [FieldAttr(nst: 72, ctr: 64)] public int _HitCount;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _GuiBossName = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _GuiBossPortrait = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _GuiBossHealthBarMaterial_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public string? _BehaviorEventTakeHitOverride = null;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _DamageOnAttackIdentifierList = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _String_List_0x78 = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _String_List_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public float _Float_0x88;
        [FieldAttr(nst: 140, ctr: 132)] public bool _IsGuiBossHealthBarBottomScreen_0x8c;
        [FieldAttr(nst: 141, ctr: 133)] public bool _Bool_0x8d;
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _GuiBossHealthBarMaterial_0x98 = new();
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _GuiBossHealthBarMaterial_0xa0 = new();
        [FieldAttr(nst: 168, ctr: 160)] public igHandleMetaField _GuiBossHealthBarMaterial_0xa8 = new();
        [FieldAttr(nst: 176, ctr: 168)] public bool _IsGuiBossHealthBarBottomScreen_0xb0;
        [FieldAttr(nst: 177, ctr: 169)] public bool _IsGuiBossHealthBarBottomScreen_0xb1;
        [FieldAttr(nst: 178, ctr: 170)] public bool _Bool_0xb2;
        [FieldAttr(nst: 180, ctr: 172)] public float _Float_0xb4;
        [FieldAttr(nst: 184, ctr: 176)] public float _Float_0xb8;
        [FieldAttr(nst: 188, ctr: 180)] public float _Float_0xbc;
        [FieldAttr(nst: 192, ctr: 184)] public EigEaseType _Ease_Type;
        [FieldAttr(nst: 196, ctr: 188)] public bool _Bool_0xc4;
        [FieldAttr(nst: 200, ctr: 192)] public string? _String = null;
    }
}
