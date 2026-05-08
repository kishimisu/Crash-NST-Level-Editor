namespace Alchemy
{
    [ObjectAttr(nst: 320, ctr: 312, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Basic_Behavior_c_Enemy_Basic_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _HurtPlayerOnContact;
        [FieldAttr(nst: 41, ctr: 33)] public bool _DestroyOnContact;
        [FieldAttr(nst: 42, ctr: 34)] public bool _DestroyOnSpin;
        [FieldAttr(nst: 43, ctr: 35)] public bool _BouncePlayerUp;
        [FieldAttr(nst: 44, ctr: 36)] public bool _DestroyOnJump;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _AkuAkuInvinciblityActive = new();
        [FieldAttr(nst: 56, ctr: 48)] public string? _CrashDeath = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _JumpDeath = null;
        [FieldAttr(nst: 72, ctr: 64)] public string? _Attack = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _Despawn = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _SpinDeath = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _DangerContactDeath = null;
        [FieldAttr(nst: 104, ctr: 96)] public string? _Idle = null;
        [FieldAttr(nst: 112, ctr: 104)] public string? _Spawn = null;
        [FieldAttr(nst: 120, ctr: 112)] public bool _Bool_0x78;
        [FieldAttr(nst: 121, ctr: 113)] public bool _Bool_0x79;
        [FieldAttr(nst: 128, ctr: 120)] public string? _String_0x80 = null;
        [FieldAttr(nst: 136, ctr: 128)] public string? _AkuDeath = null;
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0x90 = new();
        [FieldAttr(nst: 152, ctr: 144)] public bool _Bool_0x98;
        [FieldAttr(nst: 156, ctr: 148)] public float _Float_0x9c;
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xa0 = new();
        [FieldAttr(nst: 168, ctr: 160)] public bool _Bool_0xa8;
        [FieldAttr(nst: 169, ctr: 161)] public bool _Bool_0xa9;
        [FieldAttr(nst: 170, ctr: 162)] public bool _Bool_0xaa;
        [FieldAttr(nst: 172, ctr: 164)] public float _Float_0xac;
        [FieldAttr(nst: 176, ctr: 168)] public igVec2fMetaField _Vec_2F = new();
        [FieldAttr(nst: 184, ctr: 176)] public bool _Bool_0xb8;
        [FieldAttr(nst: 192, ctr: 184)] public string? _String_0xc0 = null;
        [FieldAttr(nst: 200, ctr: 192)] public igHandleMetaField _Game_Bool_Variable_0xc8 = new();
        [FieldAttr(nst: 208, ctr: 200)] public igHandleMetaField _Entity_Tag_0xd0 = new();
        [FieldAttr(nst: 216, ctr: 208)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 224, ctr: 216)] public igHandleMetaField _Bolt_Point_0xe0 = new();
        [FieldAttr(nst: 232, ctr: 224)] public igHandleMetaField _Bolt_Point_0xe8 = new();
        [FieldAttr(nst: 240, ctr: 232)] public igHandleMetaField _Game_Bool_Variable_0xf0 = new();
        [FieldAttr(nst: 248, ctr: 240)] public bool _Bool_0xf8;
        [FieldAttr(nst: 256, ctr: 248)] public string? _String_0x100 = null;
        [FieldAttr(nst: 264, ctr: 256)] public igHandleMetaField _Count = new();
        [FieldAttr(nst: 272, ctr: 264)] public bool _Bool_0x110;
        [FieldAttr(nst: 273, ctr: 265)] public bool _Bool_0x111;
        [FieldAttr(nst: 274, ctr: 266)] public bool _Bool_0x112;
        [FieldAttr(nst: 280, ctr: 272)] public string? _String_0x118 = null;
        [FieldAttr(nst: 288, ctr: 280)] public bool _Bool_0x120;
        [FieldAttr(nst: 289, ctr: 281)] public bool _Bool_0x121;
        [FieldAttr(nst: 290, ctr: 282)] public bool _Bool_0x122;
        [FieldAttr(nst: 291, ctr: 283)] public bool _Bool_0x123;
        [FieldAttr(nst: 296, ctr: 288)] public igHandleMetaField _Entity_Tag_0x128 = new();
        [FieldAttr(nst: 304, ctr: 296)] public bool _Bool_0x130;
        [FieldAttr(nst: 305, ctr: 297)] public bool _Bool_0x131;
        [FieldAttr(nst: 306, ctr: 298)] public bool _Bool_0x132;
        [FieldAttr(nst: 308, ctr: 300)] public float _Float_0x134;
        [FieldAttr(nst: 312, ctr: 304)] public bool _Bool_0x138;
    }
}
