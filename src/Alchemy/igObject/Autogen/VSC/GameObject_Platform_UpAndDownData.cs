namespace Alchemy
{
    // VSC object extracted from: GameObject_Platform_UpAndDown_c.igz

    [ObjectAttr(224, metaType: typeof(CVscComponentData))]
    public class GameObject_Platform_UpAndDownData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Start_Lowered;
        [FieldAttr(41)] public bool _Auto_Oscillate;
        [FieldAttr(42)] public bool _Start_Raised;
        [FieldAttr(43)] public bool _RaiseAnimLooping;
        [FieldAttr(44)] public bool _LowerAnimLooping;
        [FieldAttr(48)] public EigEaseType _EaseType;
        [FieldAttr(52)] public EigEaseType _TellEaseType;
        [FieldAttr(56)] public float _TellBobDuration;
        [FieldAttr(60)] public float _TellEase;
        [FieldAttr(64)] public float _EaseDuration;
        [FieldAttr(68)] public float _Offest;
        [FieldAttr(72)] public float _DurationUp;
        [FieldAttr(76)] public float _DurationDown;
        [FieldAttr(80)] public float _LowerDelay;
        [FieldAttr(84)] public float _StartDelay;
        [FieldAttr(88)] public float _RaiseDelay;
        [FieldAttr(92)] public float _TellDisplacement;
        [FieldAttr(96)] public igHandleMetaField _TellSound = new();
        [FieldAttr(104)] public igHandleMetaField _RaiseSound = new();
        [FieldAttr(112)] public igHandleMetaField _LowerSound = new();
        [FieldAttr(120)] public igHandleMetaField _LowerEvent001 = new();
        [FieldAttr(128)] public igHandleMetaField _LowerEvent = new();
        [FieldAttr(136)] public igHandleMetaField _RaiseEvent = new();
        [FieldAttr(144)] public igHandleMetaField _RaiseEvent001 = new();
        [FieldAttr(152)] public string? _RaiseAnimation = null;
        [FieldAttr(160)] public string? _TellAnimation = null;
        [FieldAttr(168)] public string? _LowerAnimation = null;
        [FieldAttr(176)] public igHandleMetaField _TellVFX = new();
        [FieldAttr(184)] public igHandleMetaField _LowerVFX = new();
        [FieldAttr(192)] public igHandleMetaField _RaiseVFX = new();
        [FieldAttr(200)] public bool _Bool_0xc8;
        [FieldAttr(204)] public float _Float_0xcc;
        [FieldAttr(208)] public float _Float_0xd0;
        [FieldAttr(212)] public float _Float_0xd4;
        [FieldAttr(216)] public float _Float_0xd8;
        [FieldAttr(220)] public bool _Bool_0xdc;
    }
}
