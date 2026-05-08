namespace Alchemy
{
    [ObjectAttr(nst: 256, ctr: 248, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_BasicMover_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _UseSoftPosReset;
        [FieldAttr(nst: 41, ctr: 33)] public bool _UseSpline;
        [FieldAttr(nst: 42, ctr: 34)] public bool _UseInitDelay;
        [FieldAttr(nst: 43, ctr: 35)] public bool _isLooping_0x2b;
        [FieldAttr(nst: 44, ctr: 36)] public float _ReturnEaseIn;
        [FieldAttr(nst: 48, ctr: 40)] public float _ReturnDuration;
        [FieldAttr(nst: 52, ctr: 44)] public float _ReturnEaseOut;
        [FieldAttr(nst: 56, ctr: 48)] public float _MovementDuration;
        [FieldAttr(nst: 60, ctr: 52)] public float _EaseOut;
        [FieldAttr(nst: 64, ctr: 56)] public float _ReturnDelay;
        [FieldAttr(nst: 68, ctr: 60)] public float _InitialDelay;
        [FieldAttr(nst: 72, ctr: 64)] public float _WarningDuration;
        [FieldAttr(nst: 76, ctr: 68)] public float _EaseIn;
        [FieldAttr(nst: 80, ctr: 72)] public float _IdleDuration;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Return_Sfx = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Warning_Sfx = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Movement_Sfx = new();
        [FieldAttr(nst: 120, ctr: 112)] public string? _Settle = null;
        [FieldAttr(nst: 128, ctr: 120)] public string? _Warning = null;
        [FieldAttr(nst: 136, ctr: 128)] public string? _Return = null;
        [FieldAttr(nst: 144, ctr: 136)] public string? _Movement = null;
        [FieldAttr(nst: 152, ctr: 144)] public igVec3fMetaField _MovementOffset = new();
        [FieldAttr(nst: 168, ctr: 160)] public igHandleMetaField _Return_Vfx = new();
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _Movement_Vfx = new();
        [FieldAttr(nst: 184, ctr: 176)] public igHandleMetaField _Warning_Vfx_0xb8 = new();
        [FieldAttr(nst: 192, ctr: 184)] public igHandleMetaField _Idle_Vfx = new();
        [FieldAttr(nst: 200, ctr: 192)] public bool _Bool_0xc8;
        [FieldAttr(nst: 208, ctr: 200)] public igHandleMetaField _Warning_Vfx_0xd0 = new();
        [FieldAttr(nst: 216, ctr: 208)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 224, ctr: 216)] public bool _isLooping_0xe0;
        [FieldAttr(nst: 225, ctr: 217)] public bool _Bool_0xe1;
        [FieldAttr(nst: 232, ctr: 224)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 240, ctr: 232)] public bool _Bool_0xf0;
        [FieldAttr(nst: 248, ctr: 240)] public igHandleMetaField _Vfx_Effect = new();
    }
}
