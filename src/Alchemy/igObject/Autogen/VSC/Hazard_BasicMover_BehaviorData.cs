namespace Alchemy
{
    // VSC object extracted from: Hazard_BasicMover_Behavior_c.igz

    [ObjectAttr(256, metaType: typeof(CVscComponentData))]
    public class Hazard_BasicMover_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _UseSoftPosReset;
        [FieldAttr(41)] public bool _UseSpline;
        [FieldAttr(42)] public bool _UseInitDelay;
        [FieldAttr(43)] public bool _isLooping_0x2b;
        [FieldAttr(44)] public float _ReturnEaseIn;
        [FieldAttr(48)] public float _ReturnDuration;
        [FieldAttr(52)] public float _ReturnEaseOut;
        [FieldAttr(56)] public float _MovementDuration;
        [FieldAttr(60)] public float _EaseOut;
        [FieldAttr(64)] public float _ReturnDelay;
        [FieldAttr(68)] public float _InitialDelay;
        [FieldAttr(72)] public float _WarningDuration;
        [FieldAttr(76)] public float _EaseIn;
        [FieldAttr(80)] public float _IdleDuration;
        [FieldAttr(88)] public igHandleMetaField _Return_Sfx = new();
        [FieldAttr(96)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(104)] public igHandleMetaField _Warning_Sfx = new();
        [FieldAttr(112)] public igHandleMetaField _Movement_Sfx = new();
        [FieldAttr(120)] public string? _Settle = null;
        [FieldAttr(128)] public string? _Warning = null;
        [FieldAttr(136)] public string? _Return = null;
        [FieldAttr(144)] public string? _Movement = null;
        [FieldAttr(152)] public igVec3fMetaField _MovementOffset = new();
        [FieldAttr(168)] public igHandleMetaField _Return_Vfx = new();
        [FieldAttr(176)] public igHandleMetaField _Movement_Vfx = new();
        [FieldAttr(184)] public igHandleMetaField _Warning_Vfx_0xb8 = new();
        [FieldAttr(192)] public igHandleMetaField _Idle_Vfx = new();
        [FieldAttr(200)] public bool _Bool_0xc8;
        [FieldAttr(208)] public igHandleMetaField _Warning_Vfx_0xd0 = new();
        [FieldAttr(216)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(224)] public bool _isLooping_0xe0;
        [FieldAttr(225)] public bool _Bool_0xe1;
        [FieldAttr(232)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(240)] public bool _Bool_0xf0;
        [FieldAttr(248)] public igHandleMetaField _Vfx_Effect = new();
    }
}
