namespace Alchemy
{
    [ObjectAttr(nst: 160, ctr: 152, align: 4, metaType: typeof(CVscComponentData))]
    public class common_BossJumpToPositionData : CVscComponentData
    {
        public enum ENewEnum7_id_i6t67tyq
        {
            None = 0,
            OnGraphEvent = 1,
            OnCustomEvent = 2,
        }

        [FieldAttr(nst: 40, ctr: 32)] public bool _IsFallLandGroundCastOn;
        [FieldAttr(nst: 44, ctr: 36)] public EigEaseType _JumpToZPositionEaseType;
        [FieldAttr(nst: 48, ctr: 40)] public EigEaseType _FallToZPositionEaseType;
        [FieldAttr(nst: 52, ctr: 44)] public EigEaseType _JumpToXYPositionEaseType;
        [FieldAttr(nst: 56, ctr: 48)] public EigEaseType _TurnEaseType;
        [FieldAttr(nst: 60, ctr: 52)] public float _TurnEaseRatioIn;
        [FieldAttr(nst: 64, ctr: 56)] public float _TurnEaseRatioOut;
        [FieldAttr(nst: 68, ctr: 60)] public float _JumpToZPositionEaseRatioIn;
        [FieldAttr(nst: 72, ctr: 64)] public float _JumpToZPositionEaseRatioOut;
        [FieldAttr(nst: 76, ctr: 68)] public float _JumpToXYPositionEaseRatioIn;
        [FieldAttr(nst: 80, ctr: 72)] public float _JumpToXYPositionEaseRatioOut;
        [FieldAttr(nst: 84, ctr: 76)] public float _FallToZPositionEaseRatioIn;
        [FieldAttr(nst: 88, ctr: 80)] public float _FallToZPositionEaseRatioOut;
        [FieldAttr(nst: 96, ctr: 88)] public string? _BehaviorEventJumpStart = null;
        [FieldAttr(nst: 104, ctr: 96)] public string? _BehaviorEventFallStart = null;
        [FieldAttr(nst: 112, ctr: 104)] public string? _BehaviorEventFallLand = null;
        [FieldAttr(nst: 120, ctr: 112)] public string? _BehaviorStateMachineJump = null;
        [FieldAttr(nst: 128, ctr: 120)] public string? _BehaviorStateJumpStart = null;
        [FieldAttr(nst: 136, ctr: 128)] public string? _BehaviorStateFall = null;
        [FieldAttr(nst: 144, ctr: 136)] public string? _String = null;
        [FieldAttr(nst: 152, ctr: 144)] public ENewEnum7_id_i6t67tyq _NewEnum7_id_i6t67tyq;
    }
}
