namespace Alchemy
{
    // VSC object extracted from: GameObject_Platform_FallAway_c.igz

    [ObjectAttr(256, metaType: typeof(CVscComponentData))]
    public class GameObject_Platform_FallAwayData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Reset_0x28;
        [FieldAttr(41)] public bool _DropAnimLooping;
        [FieldAttr(42)] public bool _UseTrigger;
        [FieldAttr(43)] public bool _HideOnDropFinish_0x2b;
        [FieldAttr(44)] public bool _ResetAnimLooping;
        [FieldAttr(48)] public EigEaseType _EaseType;
        [FieldAttr(52)] public EigEaseType _TellEaseType;
        [FieldAttr(56)] public float _JumpVFXDelay;
        [FieldAttr(60)] public float _TellEase;
        [FieldAttr(64)] public float _TellBobDuration;
        [FieldAttr(68)] public float _TellDisplacement;
        [FieldAttr(72)] public float _DurationDown;
        [FieldAttr(76)] public float _DurationUp;
        [FieldAttr(80)] public float _ResetDelay;
        [FieldAttr(84)] public float _DropOffest;
        [FieldAttr(88)] public float _EaseDuration;
        [FieldAttr(92)] public float _DurationBeforeFall;
        [FieldAttr(96)] public igHandleMetaField _DropSound = new();
        [FieldAttr(104)] public igHandleMetaField _ResetSound = new();
        [FieldAttr(112)] public igHandleMetaField _TellSound_0x70 = new();
        [FieldAttr(120)] public string? _DropAnimation_0x78 = null;
        [FieldAttr(128)] public string? _TellAnimation = null;
        [FieldAttr(136)] public string? _ResetAnimation = null;
        [FieldAttr(144)] public string? _IdleAnimation = null;
        [FieldAttr(152)] public igHandleMetaField _JumpContact_Vfx_Effect = new();
        [FieldAttr(160)] public igHandleMetaField _ResetVFX = new();
        [FieldAttr(168)] public igHandleMetaField _TellVFX_0xa8 = new();
        [FieldAttr(176)] public igHandleMetaField _DropVFX = new();
        [FieldAttr(184)] public bool _Reset_0xb8;
        [FieldAttr(185)] public bool _HideOnDropFinish_0xb9;
        [FieldAttr(186)] public bool _Bool;
        [FieldAttr(192)] public string? _DropAnimation_0xc0 = null;
        [FieldAttr(200)] public igHandleMetaField _TellVFX_0xc8 = new();
        [FieldAttr(208)] public igHandleMetaField _TellSound_0xd0 = new();
        [FieldAttr(216)] public igHandleMetaField _TellVFX_0xd8 = new();
        [FieldAttr(224)] public igHandleMetaField _TellSound_0xe0 = new();
        [FieldAttr(232)] public float _Float_0xe8;
        [FieldAttr(236)] public float _Float_0xec;
        [FieldAttr(240)] public float _Float_0xf0;
        [FieldAttr(244)] public float _Float_0xf4;
        [FieldAttr(248)] public float _Float_0xf8;
        [FieldAttr(252)] public float _Float_0xfc;
    }
}
