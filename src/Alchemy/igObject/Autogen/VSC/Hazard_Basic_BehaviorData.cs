namespace Alchemy
{
    // VSC object extracted from: Hazard_Basic_Behavior_c.igz

    [ObjectAttr(192, metaType: typeof(CVscComponentData))]
    public class Hazard_Basic_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _DestroyOnJump;
        [FieldAttr(41)] public bool _BouncePlayerUp;
        [FieldAttr(42)] public bool _DestroyOnSpin;
        [FieldAttr(43)] public bool _HurtPlayerOnContact;
        [FieldAttr(44)] public bool _StopMotion;
        [FieldAttr(48)] public float _AttackDelay;
        [FieldAttr(56)] public string? _Idle = null;
        [FieldAttr(64)] public string? _Attack = null;
        [FieldAttr(72)] public string? _CrashDeath_0x48 = null;
        [FieldAttr(80)] public bool _Bool_0x50;
        [FieldAttr(84)] public float _Float_0x54;
        [FieldAttr(88)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
        [FieldAttr(96)] public bool _Bool_0x60;
        [FieldAttr(104)] public igHandleMetaField _Sound_0x68 = new();
        [FieldAttr(112)] public bool _Bool_0x70;
        [FieldAttr(120)] public string? _String = null;
        [FieldAttr(128)] public bool _Bool_0x80;
        [FieldAttr(132)] public float _Float_0x84;
        [FieldAttr(136)] public igHandleMetaField _Sound_0x88 = new();
        [FieldAttr(144)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(152)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(160)] public bool _Bool_0xa0;
        [FieldAttr(164)] public float _Float_0xa4;
        [FieldAttr(168)] public string? _CrashDeath_0xa8 = null;
        [FieldAttr(176)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(184)] public bool _Bool_0xb8;
    }
}
