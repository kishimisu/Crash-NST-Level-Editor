namespace Alchemy
{
    [ObjectAttr(nst: 176, ctr: 168, align: 4, metaType: typeof(CVscComponentData))]
    public class GameObject_Platform_AutoSplineData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _StartSplineForward;
        [FieldAttr(nst: 41, ctr: 33)] public bool _KillOnFinish;
        [FieldAttr(nst: 42, ctr: 34)] public bool _AutoLoopSpline;
        [FieldAttr(nst: 43, ctr: 35)] public bool _MoveAnimLooping;
        [FieldAttr(nst: 44, ctr: 36)] public bool _PlaySplineOnContact;
        [FieldAttr(nst: 48, ctr: 40)] public EigEaseType _TellEaseType;
        [FieldAttr(nst: 52, ctr: 44)] public float _TellEase;
        [FieldAttr(nst: 56, ctr: 48)] public float _TellBobDuration;
        [FieldAttr(nst: 60, ctr: 52)] public float _StartingRatio;
        [FieldAttr(nst: 64, ctr: 56)] public float _TellDisplacement;
        [FieldAttr(nst: 68, ctr: 60)] public float _TurnDelay;
        [FieldAttr(nst: 72, ctr: 64)] public float _TellDelay;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Turn_Delay_Float_List = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _MoveSound = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _IdleSound = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _TellSound = new();
        [FieldAttr(nst: 112, ctr: 104)] public string? _TellAnimation = null;
        [FieldAttr(nst: 120, ctr: 112)] public string? _MoveAnimation = null;
        [FieldAttr(nst: 128, ctr: 120)] public string? _IdleAnimation = null;
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _MoveVFX = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _IdleVFX = new();
        [FieldAttr(nst: 152, ctr: 144)] public igHandleMetaField _TellVFX = new();
        [FieldAttr(nst: 160, ctr: 152)] public bool _Bool_0xa0;
        [FieldAttr(nst: 164, ctr: 156)] public float _Float;
        [FieldAttr(nst: 168, ctr: 160)] public bool _Bool_0xa8;
    }
}
