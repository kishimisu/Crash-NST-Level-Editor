namespace Alchemy
{
    // VSC object extracted from: EnemyTrackPlayerPositionBehavior_c.igz

    [ObjectAttr(192, metaType: typeof(CVscComponentData))]
    public class EnemyTrackPlayerPositionBehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public bool _HurtPlayerWhileFlipped;
        [FieldAttr(41)] public bool _HurtPlayerAfterFlipped;
        [FieldAttr(48)] public igHandleMetaField _splineLane = new();
        [FieldAttr(56)] public igHandleMetaField _PatrolEntity = new();
        [FieldAttr(64)] public igHandleMetaField _TriggerVolumeEntity = new();
        [FieldAttr(72)] public float _ClampDistance;
        [FieldAttr(76)] public float _FlippedTimer;
        [FieldAttr(80)] public float _PatrolDelay;
        [FieldAttr(88)] public string? _WalkBack = null;
        [FieldAttr(96)] public string? _TurnForwardToBack = null;
        [FieldAttr(104)] public string? _TurnBackToFront = null;
        [FieldAttr(112)] public string? _BounceInitial = null;
        [FieldAttr(120)] public string? _WalkForward = null;
        [FieldAttr(128)] public string? _JumpBounce = null;
        [FieldAttr(136)] public string? _BounceRecover = null;
        [FieldAttr(144)] public string? _BounceIdle = null;
        [FieldAttr(152)] public string? _BounceRecoverTell = null;
        [FieldAttr(160)] public float _Float;
        [FieldAttr(168)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xa8 = new();
        [FieldAttr(176)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xb0 = new();
        [FieldAttr(184)] public bool _Bool_0xb8;
        [FieldAttr(185)] public bool _Bool_0xb9;
        [FieldAttr(186)] public bool _Bool_0xba;
        [FieldAttr(187)] public bool _Bool_0xbb;
    }
}
