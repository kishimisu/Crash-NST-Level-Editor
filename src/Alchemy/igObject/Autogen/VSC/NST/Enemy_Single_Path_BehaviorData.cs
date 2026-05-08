namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Single_Path_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _JumpWhenStopped;
        [FieldAttr(nst: 41, ctr: 33)] public bool _AttachOnStart;
        [FieldAttr(nst: 42, ctr: 34)] public bool _SpinWhenStopped;
        [FieldAttr(nst: 43, ctr: 35)] public bool _SpinWhenMoving;
        [FieldAttr(nst: 44, ctr: 36)] public bool _JumpWhenMoving;
        [FieldAttr(nst: 45, ctr: 37)] public bool _TrackPlayerPosition;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _splineLane = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Speed;
        [FieldAttr(nst: 60, ctr: 52)] public float _EndDelay;
        [FieldAttr(nst: 64, ctr: 56)] public float _ClampDistance;
        [FieldAttr(nst: 72, ctr: 64)] public string? _Despawn = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _WalkForward = null;
        [FieldAttr(nst: 88, ctr: 80)] public string? _Spawn = null;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _PatrolEntity = new();
        [FieldAttr(nst: 104, ctr: 96)] public bool _Bool_0x68;
        [FieldAttr(nst: 105, ctr: 97)] public bool _Bool_0x69;
    }
}
