namespace Alchemy
{
    [ObjectAttr(nst: 256, ctr: 248, align: 4, metaType: typeof(CVscComponentData))]
    public class GameObject_Platform_FallAwayData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Reset_0x28;
        [FieldAttr(nst: 41, ctr: 33)] public bool _DropAnimLooping;
        [FieldAttr(nst: 42, ctr: 34)] public bool _UseTrigger;
        [FieldAttr(nst: 43, ctr: 35)] public bool _HideOnDropFinish_0x2b;
        [FieldAttr(nst: 44, ctr: 36)] public bool _ResetAnimLooping;
        [FieldAttr(nst: 48, ctr: 40)] public EigEaseType _EaseType;
        [FieldAttr(nst: 52, ctr: 44)] public EigEaseType _TellEaseType;
        [FieldAttr(nst: 56, ctr: 48)] public float _JumpVFXDelay;
        [FieldAttr(nst: 60, ctr: 52)] public float _TellEase;
        [FieldAttr(nst: 64, ctr: 56)] public float _TellBobDuration;
        [FieldAttr(nst: 68, ctr: 60)] public float _TellDisplacement;
        [FieldAttr(nst: 72, ctr: 64)] public float _DurationDown;
        [FieldAttr(nst: 76, ctr: 68)] public float _DurationUp;
        [FieldAttr(nst: 80, ctr: 72)] public float _ResetDelay;
        [FieldAttr(nst: 84, ctr: 76)] public float _DropOffest;
        [FieldAttr(nst: 88, ctr: 80)] public float _EaseDuration;
        [FieldAttr(nst: 92, ctr: 84)] public float _DurationBeforeFall;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _DropSound = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _ResetSound = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _TellSound_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public string? _DropAnimation_0x78 = null;
        [FieldAttr(nst: 128, ctr: 120)] public string? _TellAnimation = null;
        [FieldAttr(nst: 136, ctr: 128)] public string? _ResetAnimation = null;
        [FieldAttr(nst: 144, ctr: 136)] public string? _IdleAnimation = null;
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _JumpContact_Vfx_Effect = new();
        [FieldAttr(nst: 160, ctr: 152)] public igHandleMetaField _ResetVFX = new();
        [FieldAttr(nst: 168, ctr: 160)] public igHandleMetaField _TellVFX_0xa8 = new();
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _DropVFX = new();
        [FieldAttr(nst: 184, ctr: 176)] public bool _Reset_0xb8;
        [FieldAttr(nst: 185, ctr: 177)] public bool _HideOnDropFinish_0xb9;
        [FieldAttr(nst: 186, ctr: 178)] public bool _Bool;
        [FieldAttr(nst: 192, ctr: 184)] public string? _DropAnimation_0xc0 = null;
        [FieldAttr(nst: 200, ctr: 192)] public igHandleMetaField _TellVFX_0xc8 = new();
        [FieldAttr(nst: 208, ctr: 200)] public igHandleMetaField _TellSound_0xd0 = new();
        [FieldAttr(nst: 216, ctr: 208)] public igHandleMetaField _TellVFX_0xd8 = new();
        [FieldAttr(nst: 224, ctr: 216)] public igHandleMetaField _TellSound_0xe0 = new();
        [FieldAttr(nst: 232, ctr: 224)] public float _Float_0xe8;
        [FieldAttr(nst: 236, ctr: 228)] public float _Float_0xec;
        [FieldAttr(nst: 240, ctr: 232)] public float _Float_0xf0;
        [FieldAttr(nst: 244, ctr: 236)] public float _Float_0xf4;
        [FieldAttr(nst: 248, ctr: 240)] public float _Float_0xf8;
        [FieldAttr(nst: 252, ctr: 244)] public float _Float_0xfc;
    }
}
