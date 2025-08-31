using Alchemy;

namespace Havok
{
    [ObjectAttr(64)]
    public class hknpMotionProperties : hkObject
    {
        public override uint Hash => 0x5dee8641;

        [FieldAttr(0)] public u32 _isExclusive; // TYPE_UINT32
        [FieldAttr(4)] public u32 _flags; // TYPE_FLAGS, etype: FlagsEnum, subtype: TYPE_UINT32
        [FieldAttr(8)] public float _gravityFactor; // TYPE_REAL
        [FieldAttr(12)] public float _timeFactor; // TYPE_REAL
        [FieldAttr(16)] public float _maxLinearSpeed; // TYPE_REAL
        [FieldAttr(20)] public float _maxAngularSpeed; // TYPE_REAL
        [FieldAttr(24)] public float _linearDamping; // TYPE_REAL
        [FieldAttr(28)] public float _angularDamping; // TYPE_REAL
        [FieldAttr(32)] public float _solverStabilizationSpeedThreshold; // TYPE_REAL
        [FieldAttr(36)] public float _solverStabilizationSpeedReduction; // TYPE_REAL
        [FieldAttr(40)] public float _maxDistSqrd; // TYPE_REAL
        [FieldAttr(44)] public float _maxRotSqrd; // TYPE_REAL
        [FieldAttr(48)] public float _invBlockSize; // TYPE_REAL
        [FieldAttr(52)] public i16 _pathingUpperThreshold; // TYPE_INT16
        [FieldAttr(54)] public i16 _pathingLowerThreshold; // TYPE_INT16
        [FieldAttr(56)] public u8 _numDeactivationFrequencyPasses; // TYPE_UINT8
        [FieldAttr(57)] public u8 _deactivationVelocityScaleSquare; // TYPE_UINT8
        [FieldAttr(58)] public u8 _minimumPathingVelocityScaleSquare; // TYPE_UINT8
        [FieldAttr(59)] public u8 _spikingVelocityScaleThresholdSquared; // TYPE_UINT8
        [FieldAttr(60)] public u8 _minimumSpikingVelocityScaleSquared; // TYPE_UINT8
    }
}