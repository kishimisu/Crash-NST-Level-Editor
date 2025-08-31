namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class CVehicleRampComponentData : CEntityComponentData
    {
        public enum EBoostForwardDirectionOverride : uint
        {
            eBFDO_None = 0,
            eBFDO_X = 1,
            eBFDO_Y = 2,
        }

        public enum ERampJumpMode : uint
        {
            eRJM_Spline = 0,
            eRJM_Impulse = 1,
        }

        [FieldAttr(24)] public float _minVelocityRequired = 300.0f;
        [FieldAttr(32)] public CEntityData? _dummySplineEntityData;
        [FieldAttr(40)] public bool _applyRotationalKeyframes;
        [FieldAttr(48)] public CVehicleBoostData? _vehicleBoost;
        [FieldAttr(56)] public float _maxHorizontalAngleDifferenceForActivation = 180.0f;
        [FieldAttr(60)] public EBoostForwardDirectionOverride _boostForwardDirectionOverride;
        [FieldAttr(64)] public igHandleMetaField _activatedVfx = new();
        [FieldAttr(72)] public CBoltPoint? _boostPadBoltPoint;
        [FieldAttr(80)] public ERampJumpMode _rampJumpMode = CVehicleRampComponentData.ERampJumpMode.eRJM_Impulse;
        [FieldAttr(84)] public float _rampTime;
        [FieldAttr(88)] public igVec3fMetaField _rampImpulse = new();
    }
}
