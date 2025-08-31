namespace Alchemy
{
    // VSC object extracted from: Enemy_Havok_Basic_Behavior.igz

    [ObjectAttr(296, metaType: typeof(CVscComponentData))]
    public class Enemy_Havok_Basic_Behavior_Enemy_Basic_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Enemy_Basic_BehaviorDatas004;
        [FieldAttr(41)] public bool _DestroyOnContact;
        [FieldAttr(42)] public bool _DestroyOnSpin;
        [FieldAttr(43)] public bool _BouncePlayerUp;
        [FieldAttr(44)] public bool _DestroyOnJump;
        [FieldAttr(48)] public igHandleMetaField _AkuAkuInvinciblityActive = new();
        [FieldAttr(56)] public string? _CrashDeath = null;
        [FieldAttr(64)] public string? _Enemy_Basic_BehaviorDatas006 = null;
        [FieldAttr(72)] public string? _Attack = null;
        [FieldAttr(80)] public string? _Enemy_Basic_BehaviorDatas008 = null;
        [FieldAttr(88)] public string? _DangerContactDeath = null;
        [FieldAttr(96)] public bool _Bool_0x60;
        [FieldAttr(97)] public bool _Bool_0x61;
        [FieldAttr(104)] public string? _Enemy_Basic_BehaviorDatas009 = null;
        [FieldAttr(112)] public string? _AkuDeath = null;
        [FieldAttr(120)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x78 = new();
        [FieldAttr(128)] public bool _Bool_0x80;
        [FieldAttr(132)] public float _Enemy_Basic_BehaviorDatas002;
        [FieldAttr(136)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x88 = new();
        [FieldAttr(144)] public bool _Bool_0x90;
        [FieldAttr(145)] public bool _Bool_0x91;
        [FieldAttr(146)] public bool _Bool_0x92;
        [FieldAttr(148)] public float _Enemy_Basic_BehaviorDatas001;
        [FieldAttr(152)] public igVec2fMetaField _Enemy_Basic_BehaviorDatas011 = new();
        [FieldAttr(160)] public bool _Bool_0xa0;
        [FieldAttr(168)] public string? _Enemy_Basic_BehaviorDatas010 = null;
        [FieldAttr(176)] public igHandleMetaField _Enemy_Basic_BehaviorDatas003 = new();
        [FieldAttr(184)] public igHandleMetaField _Enemy_Basic_BehaviorDatas = new();
        [FieldAttr(192)] public bool _Bool_0xc0;
        [FieldAttr(200)] public string? _String_0xc8 = null;
        [FieldAttr(208)] public string? _String_0xd0 = null;
        [FieldAttr(216)] public string? _String_0xd8 = null;
        [FieldAttr(224)] public bool _Bool_0xe0;
        [FieldAttr(232)] public string? _String_0xe8 = null;
        [FieldAttr(240)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(248)] public string? _String_0xf8 = null;
        [FieldAttr(256)] public bool _Bool_0x100;
        [FieldAttr(257)] public bool _Bool_0x101;
        [FieldAttr(260)] public float _Float_0x104;
        [FieldAttr(264)] public bool _Bool_0x108;
        [FieldAttr(268)] public float _Float_0x10c;
        [FieldAttr(272)] public bool _Bool_0x110;
        [FieldAttr(280)] public string? _String_0x118 = null;
        [FieldAttr(288)] public bool _Bool_0x120;
        [FieldAttr(289)] public bool _Bool_0x121;
        [FieldAttr(290)] public bool _Bool_0x122;
    }
}
