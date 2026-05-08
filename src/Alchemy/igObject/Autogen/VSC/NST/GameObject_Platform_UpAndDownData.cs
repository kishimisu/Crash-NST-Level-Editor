namespace Alchemy
{
    [ObjectAttr(nst: 224, ctr: 216, align: 4, metaType: typeof(CVscComponentData))]
    public class GameObject_Platform_UpAndDownData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Start_Lowered;
        [FieldAttr(nst: 41, ctr: 33)] public bool _Auto_Oscillate;
        [FieldAttr(nst: 42, ctr: 34)] public bool _Start_Raised;
        [FieldAttr(nst: 43, ctr: 35)] public bool _RaiseAnimLooping;
        [FieldAttr(nst: 44, ctr: 36)] public bool _LowerAnimLooping;
        [FieldAttr(nst: 48, ctr: 40)] public EigEaseType _EaseType;
        [FieldAttr(nst: 52, ctr: 44)] public EigEaseType _TellEaseType;
        [FieldAttr(nst: 56, ctr: 48)] public float _TellBobDuration;
        [FieldAttr(nst: 60, ctr: 52)] public float _TellEase;
        [FieldAttr(nst: 64, ctr: 56)] public float _EaseDuration;
        [FieldAttr(nst: 68, ctr: 60)] public float _Offest;
        [FieldAttr(nst: 72, ctr: 64)] public float _DurationUp;
        [FieldAttr(nst: 76, ctr: 68)] public float _DurationDown;
        [FieldAttr(nst: 80, ctr: 72)] public float _LowerDelay;
        [FieldAttr(nst: 84, ctr: 76)] public float _StartDelay;
        [FieldAttr(nst: 88, ctr: 80)] public float _RaiseDelay;
        [FieldAttr(nst: 92, ctr: 84)] public float _TellDisplacement;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _TellSound = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _RaiseSound = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _LowerSound = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _LowerEvent001 = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _LowerEvent = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _RaiseEvent = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _RaiseEvent001 = new();
        [FieldAttr(nst: 152, ctr: 144)] public string? _RaiseAnimation = null;
        [FieldAttr(nst: 160, ctr: 152)] public string? _TellAnimation = null;
        [FieldAttr(nst: 168, ctr: 160)] public string? _LowerAnimation = null;
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _TellVFX = new();
        [FieldAttr(nst: 184, ctr: 176)] public igHandleMetaField _LowerVFX = new();
        [FieldAttr(nst: 192, ctr: 184)] public igHandleMetaField _RaiseVFX = new();
        [FieldAttr(nst: 200, ctr: 192)] public bool _Bool_0xc8;
        [FieldAttr(nst: 204, ctr: 196)] public float _Float_0xcc;
        [FieldAttr(nst: 208, ctr: 200)] public float _Float_0xd0;
        [FieldAttr(nst: 212, ctr: 204)] public float _Float_0xd4;
        [FieldAttr(nst: 216, ctr: 208)] public float _Float_0xd8;
        [FieldAttr(nst: 220, ctr: 212)] public bool _Bool_0xdc;
    }
}
