namespace Alchemy
{
    // VSC object extracted from: GameObject_Platform_AutoSpline_c.igz

    [ObjectAttr(176, metaType: typeof(CVscComponentData))]
    public class GameObject_Platform_AutoSplineData : CVscComponentData
    {
        [FieldAttr(40)] public bool _StartSplineForward;
        [FieldAttr(41)] public bool _KillOnFinish;
        [FieldAttr(42)] public bool _AutoLoopSpline;
        [FieldAttr(43)] public bool _MoveAnimLooping;
        [FieldAttr(44)] public bool _PlaySplineOnContact;
        [FieldAttr(48)] public EigEaseType _TellEaseType;
        [FieldAttr(52)] public float _TellEase;
        [FieldAttr(56)] public float _TellBobDuration;
        [FieldAttr(60)] public float _StartingRatio;
        [FieldAttr(64)] public float _TellDisplacement;
        [FieldAttr(68)] public float _TurnDelay;
        [FieldAttr(72)] public float _TellDelay;
        [FieldAttr(80)] public igHandleMetaField _Turn_Delay_Float_List = new();
        [FieldAttr(88)] public igHandleMetaField _MoveSound = new();
        [FieldAttr(96)] public igHandleMetaField _IdleSound = new();
        [FieldAttr(104)] public igHandleMetaField _TellSound = new();
        [FieldAttr(112)] public string? _TellAnimation = null;
        [FieldAttr(120)] public string? _MoveAnimation = null;
        [FieldAttr(128)] public string? _IdleAnimation = null;
        [FieldAttr(136)] public igHandleMetaField _MoveVFX = new();
        [FieldAttr(144)] public igHandleMetaField _IdleVFX = new();
        [FieldAttr(152)] public igHandleMetaField _TellVFX = new();
        [FieldAttr(160)] public bool _Bool_0xa0;
        [FieldAttr(164)] public float _Float;
        [FieldAttr(168)] public bool _Bool_0xa8;
    }
}
