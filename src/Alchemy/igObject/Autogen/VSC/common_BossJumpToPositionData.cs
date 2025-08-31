namespace Alchemy
{
    // VSC object extracted from: common_BossJumpToPosition_c.igz

    [ObjectAttr(160, metaType: typeof(CVscComponentData))]
    public class common_BossJumpToPositionData : CVscComponentData
    {
        public enum ENewEnum7_id_i6t67tyq
        {
            None = 0,
            OnGraphEvent = 1,
            OnCustomEvent = 2,
        }

        [FieldAttr(40)] public bool _IsFallLandGroundCastOn;
        [FieldAttr(44)] public EigEaseType _JumpToZPositionEaseType;
        [FieldAttr(48)] public EigEaseType _FallToZPositionEaseType;
        [FieldAttr(52)] public EigEaseType _JumpToXYPositionEaseType;
        [FieldAttr(56)] public EigEaseType _TurnEaseType;
        [FieldAttr(60)] public float _TurnEaseRatioIn;
        [FieldAttr(64)] public float _TurnEaseRatioOut;
        [FieldAttr(68)] public float _JumpToZPositionEaseRatioIn;
        [FieldAttr(72)] public float _JumpToZPositionEaseRatioOut;
        [FieldAttr(76)] public float _JumpToXYPositionEaseRatioIn;
        [FieldAttr(80)] public float _JumpToXYPositionEaseRatioOut;
        [FieldAttr(84)] public float _FallToZPositionEaseRatioIn;
        [FieldAttr(88)] public float _FallToZPositionEaseRatioOut;
        [FieldAttr(96)] public string? _BehaviorEventJumpStart = null;
        [FieldAttr(104)] public string? _BehaviorEventFallStart = null;
        [FieldAttr(112)] public string? _BehaviorEventFallLand = null;
        [FieldAttr(120)] public string? _BehaviorStateMachineJump = null;
        [FieldAttr(128)] public string? _BehaviorStateJumpStart = null;
        [FieldAttr(136)] public string? _BehaviorStateFall = null;
        [FieldAttr(144)] public string? _String = null;
        [FieldAttr(152)] public ENewEnum7_id_i6t67tyq _NewEnum7_id_i6t67tyq;
    }
}
