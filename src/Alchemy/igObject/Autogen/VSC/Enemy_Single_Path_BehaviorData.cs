namespace Alchemy
{
    // VSC object extracted from: Enemy_Single_Path_Behavior_c.igz

    [ObjectAttr(112, metaType: typeof(CVscComponentData))]
    public class Enemy_Single_Path_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _JumpWhenStopped;
        [FieldAttr(41)] public bool _AttachOnStart;
        [FieldAttr(42)] public bool _SpinWhenStopped;
        [FieldAttr(43)] public bool _SpinWhenMoving;
        [FieldAttr(44)] public bool _JumpWhenMoving;
        [FieldAttr(45)] public bool _TrackPlayerPosition;
        [FieldAttr(48)] public igHandleMetaField _splineLane = new();
        [FieldAttr(56)] public float _Speed;
        [FieldAttr(60)] public float _EndDelay;
        [FieldAttr(64)] public float _ClampDistance;
        [FieldAttr(72)] public string? _Despawn = null;
        [FieldAttr(80)] public string? _WalkForward = null;
        [FieldAttr(88)] public string? _Spawn = null;
        [FieldAttr(96)] public igHandleMetaField _PatrolEntity = new();
        [FieldAttr(104)] public bool _Bool_0x68;
        [FieldAttr(105)] public bool _Bool_0x69;
    }
}
