namespace Alchemy
{
    // VSC object extracted from: common_Sewer_FallAwayPlatform.igz

    [ObjectAttr(248, metaType: typeof(CVscComponentData))]
    public class common_Sewer_FallAwayPlatformData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Reset_0x28;
        [FieldAttr(44)] public float _TellEase;
        [FieldAttr(48)] public bool _UseTrigger;
        [FieldAttr(56)] public igHandleMetaField _TellSound = new();
        [FieldAttr(64)] public igHandleMetaField _TellVFX = new();
        [FieldAttr(72)] public igHandleMetaField _DropVFX = new();
        [FieldAttr(80)] public igHandleMetaField _DropSound = new();
        [FieldAttr(88)] public igHandleMetaField _ResetSound = new();
        [FieldAttr(96)] public igHandleMetaField _ResetVFX = new();
        [FieldAttr(104)] public float _ResetDelay;
        [FieldAttr(108)] public float _DurationUp;
        [FieldAttr(112)] public string? _TellAnimation = null;
        [FieldAttr(120)] public string? _IdleAnimation = null;
        [FieldAttr(128)] public float _EaseDuration;
        [FieldAttr(132)] public float _DropOffest;
        [FieldAttr(136)] public string? _DropAnimation = null;
        [FieldAttr(144)] public string? _ResetAnimation = null;
        [FieldAttr(152)] public float _DurationDown;
        [FieldAttr(156)] public float _JumpVFXDelay;
        [FieldAttr(160)] public bool _Bool_0xa0;
        [FieldAttr(161)] public bool _HideOnDropFinish_0xa1;
        [FieldAttr(164)] public float _TellBobDuration;
        [FieldAttr(168)] public bool _HideOnDropFinish_0xa8;
        [FieldAttr(169)] public bool _DropAnimLooping;
        [FieldAttr(172)] public float _TellDisplacement;
        [FieldAttr(176)] public bool _ResetAnimLooping;
        [FieldAttr(180)] public float _Float_0xb4;
        [FieldAttr(184)] public float _DurationBeforeFall;
        [FieldAttr(188)] public EigEaseType _EaseType;
        [FieldAttr(192)] public bool _Bool_0xc0;
        [FieldAttr(196)] public EigEaseType _TellEaseType;
        [FieldAttr(200)] public igHandleMetaField _JumpContact_Vfx_Effect = new();
        [FieldAttr(208)] public bool _Reset_0xd0;
        [FieldAttr(209)] public bool _Bool_0xd1;
        [FieldAttr(212)] public float _Float_0xd4;
        [FieldAttr(216)] public float _Float_0xd8;
        [FieldAttr(224)] public igHandleMetaField _Spline_Event_0xe0 = new();
        [FieldAttr(232)] public igHandleMetaField _Spline_Event_0xe8 = new();
        [FieldAttr(240)] public bool _Bool_0xf0;
        [FieldAttr(244)] public float _Float_0xf4;
    }
}
