namespace Alchemy
{
    [ObjectAttr(nst: 192, ctr: 184, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_Basic_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _DestroyOnJump;
        [FieldAttr(nst: 41, ctr: 33)] public bool _BouncePlayerUp;
        [FieldAttr(nst: 42, ctr: 34)] public bool _DestroyOnSpin;
        [FieldAttr(nst: 43, ctr: 35)] public bool _HurtPlayerOnContact;
        [FieldAttr(nst: 44, ctr: 36)] public bool _StopMotion;
        [FieldAttr(nst: 48, ctr: 40)] public float _AttackDelay;
        [FieldAttr(nst: 56, ctr: 48)] public string? _Idle = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _Attack = null;
        [FieldAttr(nst: 72, ctr: 64)] public string? _CrashDeath_0x48 = null;
        [FieldAttr(nst: 80, ctr: 72)] public bool _Bool_0x50;
        [FieldAttr(nst: 84, ctr: 76)] public float _Float_0x54;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(nst: 96, ctr: 88)] public bool _Bool_0x60;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Sound_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public bool _Bool_0x70;
        [FieldAttr(nst: 120, ctr: 112)] public string? _String = null;
        [FieldAttr(nst: 128, ctr: 120)] public bool _Bool_0x80;
        [FieldAttr(nst: 132, ctr: 124)] public float _Float_0x84;
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Sound_0x88 = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 160, ctr: 152)] public bool _Bool_0xa0;
        [FieldAttr(nst: 164, ctr: 156)] public float _Float_0xa4;
        [FieldAttr(nst: 168, ctr: 160)] public string? _CrashDeath_0xa8 = null;
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 184, ctr: 176)] public bool _Bool_0xb8;
    }
}
