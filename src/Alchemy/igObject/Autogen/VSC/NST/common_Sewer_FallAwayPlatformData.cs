namespace Alchemy
{
    [ObjectAttr(nst: 248, ctr: 240, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Sewer_FallAwayPlatformData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Reset_0x28;
        [FieldAttr(nst: 44, ctr: 36)] public float _TellEase;
        [FieldAttr(nst: 48, ctr: 40)] public bool _UseTrigger;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _TellSound = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _TellVFX = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _DropVFX = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _DropSound = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _ResetSound = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _ResetVFX = new();
        [FieldAttr(nst: 104, ctr: 96)] public float _ResetDelay;
        [FieldAttr(nst: 108, ctr: 100)] public float _DurationUp;
        [FieldAttr(nst: 112, ctr: 104)] public string? _TellAnimation = null;
        [FieldAttr(nst: 120, ctr: 112)] public string? _IdleAnimation = null;
        [FieldAttr(nst: 128, ctr: 120)] public float _EaseDuration;
        [FieldAttr(nst: 132, ctr: 124)] public float _DropOffest;
        [FieldAttr(nst: 136, ctr: 128)] public string? _DropAnimation = null;
        [FieldAttr(nst: 144, ctr: 136)] public string? _ResetAnimation = null;
        [FieldAttr(nst: 152, ctr: 144)] public float _DurationDown;
        [FieldAttr(nst: 156, ctr: 148)] public float _JumpVFXDelay;
        [FieldAttr(nst: 160, ctr: 152)] public bool _Bool_0xa0;
        [FieldAttr(nst: 161, ctr: 153)] public bool _HideOnDropFinish_0xa1;
        [FieldAttr(nst: 164, ctr: 156)] public float _TellBobDuration;
        [FieldAttr(nst: 168, ctr: 160)] public bool _HideOnDropFinish_0xa8;
        [FieldAttr(nst: 169, ctr: 161)] public bool _DropAnimLooping;
        [FieldAttr(nst: 172, ctr: 164)] public float _TellDisplacement;
        [FieldAttr(nst: 176, ctr: 168)] public bool _ResetAnimLooping;
        [FieldAttr(nst: 180, ctr: 172)] public float _Float_0xb4;
        [FieldAttr(nst: 184, ctr: 176)] public float _DurationBeforeFall;
        [FieldAttr(nst: 188, ctr: 180)] public EigEaseType _EaseType;
        [FieldAttr(nst: 192, ctr: 184)] public bool _Bool_0xc0;
        [FieldAttr(nst: 196, ctr: 188)] public EigEaseType _TellEaseType;
        [FieldAttr(nst: 200, ctr: 192)] public igHandleMetaField _JumpContact_Vfx_Effect = new();
        [FieldAttr(nst: 208, ctr: 200)] public bool _Reset_0xd0;
        [FieldAttr(nst: 209, ctr: 201)] public bool _Bool_0xd1;
        [FieldAttr(nst: 212, ctr: 204)] public float _Float_0xd4;
        [FieldAttr(nst: 216, ctr: 208)] public float _Float_0xd8;
        [FieldAttr(nst: 224, ctr: 216)] public igHandleMetaField _Spline_Event_0xe0 = new();
        [FieldAttr(nst: 232, ctr: 224)] public igHandleMetaField _Spline_Event_0xe8 = new();
        [FieldAttr(nst: 240, ctr: 232)] public bool _Bool_0xf0;
        [FieldAttr(nst: 244, ctr: 236)] public float _Float_0xf4;
    }
}
