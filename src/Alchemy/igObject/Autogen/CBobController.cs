namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class CBobController : CBaseMovementController
    {
        [FieldAttr(56)] public igRangedFloatMetaField _amplitudeRange = new();
        [FieldAttr(64)] public igRangedFloatMetaField _bobsPerSecondRange = new();
        [FieldAttr(72)] public float _damper;
        [FieldAttr(76)] public float _duration = -1.0f;
        [FieldAttr(80)] public igVec3fMetaField _bobDirection = new();
        [FieldAttr(92)] public CTransform.ETransformSpace _bobDirectionSpace = CTransform.ETransformSpace.eTS_Local;
        [FieldAttr(96)] public bool _resetOnStart;
        [FieldAttr(100)] public EBobResetType _resetType = EBobResetType.eBRT_ResetDirection;
        [FieldAttr(104)] public float _timeElapsed;
        [FieldAttr(108)] public float _lastNetTimeElapsed;
        [FieldAttr(112)] public float _previousBounceOffset;
        [FieldAttr(116)] public float _amplitude;
        [FieldAttr(120)] public float _bobsPerSecond;
    }
}
