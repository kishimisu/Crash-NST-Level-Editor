namespace Alchemy
{
    // VSC object extracted from: Enemy_Basic_Behavior_c.igz

    [ObjectAttr(320, metaType: typeof(CVscComponentData))]
    public class Enemy_Basic_Behavior_c_Enemy_Basic_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _HurtPlayerOnContact;
        [FieldAttr(41)] public bool _DestroyOnContact;
        [FieldAttr(42)] public bool _DestroyOnSpin;
        [FieldAttr(43)] public bool _BouncePlayerUp;
        [FieldAttr(44)] public bool _DestroyOnJump;
        [FieldAttr(48)] public igHandleMetaField _AkuAkuInvinciblityActive = new();
        [FieldAttr(56)] public string? _CrashDeath = null;
        [FieldAttr(64)] public string? _JumpDeath = null;
        [FieldAttr(72)] public string? _Attack = null;
        [FieldAttr(80)] public string? _Despawn = null;
        [FieldAttr(88)] public string? _SpinDeath = null;
        [FieldAttr(96)] public string? _DangerContactDeath = null;
        [FieldAttr(104)] public string? _Idle = null;
        [FieldAttr(112)] public string? _Spawn = null;
        [FieldAttr(120)] public bool _Bool_0x78;
        [FieldAttr(121)] public bool _Bool_0x79;
        [FieldAttr(128)] public string? _String_0x80 = null;
        [FieldAttr(136)] public string? _AkuDeath = null;
        [FieldAttr(144)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x90 = new();
        [FieldAttr(152)] public bool _Bool_0x98;
        [FieldAttr(156)] public float _Float_0x9c;
        [FieldAttr(160)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xa0 = new();
        [FieldAttr(168)] public bool _Bool_0xa8;
        [FieldAttr(169)] public bool _Bool_0xa9;
        [FieldAttr(170)] public bool _Bool_0xaa;
        [FieldAttr(172)] public float _Float_0xac;
        [FieldAttr(176)] public igVec2fMetaField _Vec_2F = new();
        [FieldAttr(184)] public bool _Bool_0xb8;
        [FieldAttr(192)] public string? _String_0xc0 = null;
        [FieldAttr(200)] public igHandleMetaField _Game_Bool_Variable_0xc8 = new();
        [FieldAttr(208)] public igHandleMetaField _Entity_Tag_0xd0 = new();
        [FieldAttr(216)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(224)] public igHandleMetaField _Bolt_Point_0xe0 = new();
        [FieldAttr(232)] public igHandleMetaField _Bolt_Point_0xe8 = new();
        [FieldAttr(240)] public igHandleMetaField _Game_Bool_Variable_0xf0 = new();
        [FieldAttr(248)] public bool _Bool_0xf8;
        [FieldAttr(256)] public string? _String_0x100 = null;
        [FieldAttr(264)] public igHandleMetaField _Count = new();
        [FieldAttr(272)] public bool _Bool_0x110;
        [FieldAttr(273)] public bool _Bool_0x111;
        [FieldAttr(274)] public bool _Bool_0x112;
        [FieldAttr(280)] public string? _String_0x118 = null;
        [FieldAttr(288)] public bool _Bool_0x120;
        [FieldAttr(289)] public bool _Bool_0x121;
        [FieldAttr(290)] public bool _Bool_0x122;
        [FieldAttr(291)] public bool _Bool_0x123;
        [FieldAttr(296)] public igHandleMetaField _Entity_Tag_0x128 = new();
        [FieldAttr(304)] public bool _Bool_0x130;
        [FieldAttr(305)] public bool _Bool_0x131;
        [FieldAttr(306)] public bool _Bool_0x132;
        [FieldAttr(308)] public float _Float_0x134;
        [FieldAttr(312)] public bool _Bool_0x138;
    }
}
