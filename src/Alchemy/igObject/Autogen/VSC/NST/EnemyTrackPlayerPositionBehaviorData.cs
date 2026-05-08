namespace Alchemy
{
    [ObjectAttr(nst: 192, ctr: 184, align: 4, metaType: typeof(CVscComponentData))]
    public class EnemyTrackPlayerPositionBehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _HurtPlayerWhileFlipped;
        [FieldAttr(nst: 41, ctr: 33)] public bool _HurtPlayerAfterFlipped;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _splineLane = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _PatrolEntity = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _TriggerVolumeEntity = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _ClampDistance;
        [FieldAttr(nst: 76, ctr: 68)] public float _FlippedTimer;
        [FieldAttr(nst: 80, ctr: 72)] public float _PatrolDelay;
        [FieldAttr(nst: 88, ctr: 80)] public string? _WalkBack = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _TurnForwardToBack = null;
        [FieldAttr(nst: 104, ctr: 96)] public string? _TurnBackToFront = null;
        [FieldAttr(nst: 112, ctr: 104)] public string? _BounceInitial = null;
        [FieldAttr(nst: 120, ctr: 112)] public string? _WalkForward = null;
        [FieldAttr(nst: 128, ctr: 120)] public string? _JumpBounce = null;
        [FieldAttr(nst: 136, ctr: 128)] public string? _BounceRecover = null;
        [FieldAttr(nst: 144, ctr: 136)] public string? _BounceIdle = null;
        [FieldAttr(nst: 152, ctr: 144)] public string? _BounceRecoverTell = null;
        [FieldAttr(nst: 160, ctr: 152)] public float _Float;
        [FieldAttr(nst: 168, ctr: 160)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xa8 = new();
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data_0xb0 = new();
        [FieldAttr(nst: 184, ctr: 176)] public bool _Bool_0xb8;
        [FieldAttr(nst: 185, ctr: 177)] public bool _Bool_0xb9;
        [FieldAttr(nst: 186, ctr: 178)] public bool _Bool_0xba;
        [FieldAttr(nst: 187, ctr: 179)] public bool _Bool_0xbb;
    }
}
