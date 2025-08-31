using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(256)]
    public class hknpWorldCinfo : hkObject
    {
        public override uint Hash => 0x6300cf42;

        [FieldAttr(0)] public i32 _bodyBufferCapacity; // TYPE_INT32
        [FieldAttr(8)] public u32 _userBodyBuffer; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(16)] public i32 _motionBufferCapacity; // TYPE_INT32
        [FieldAttr(24)] public u32 _userMotionBuffer; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(32)] public i32 _constraintBufferCapacity; // TYPE_INT32
        [FieldAttr(40)] public u32 _userConstraintBuffer; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(48)] public u32 _persistentStreamAllocator; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(56)] public hknpMaterialLibrary _materialLibrary; // TYPE_POINTER, ctype: hknpMaterialLibrary, subtype: TYPE_STRUCT
        [FieldAttr(64)] public hknpMotionPropertiesLibrary _motionPropertiesLibrary; // TYPE_POINTER, ctype: hknpMotionPropertiesLibrary, subtype: TYPE_STRUCT
        [FieldAttr(72)] public hknpBodyQualityLibrary _qualityLibrary; // TYPE_POINTER, ctype: hknpBodyQualityLibrary, subtype: TYPE_STRUCT
        [FieldAttr(80)] public ESimulationType _simulationType; // TYPE_ENUM, etype: SimulationType, subtype: TYPE_UINT8
        [FieldAttr(84)] public i32 _numSplitterCells; // TYPE_INT32
        [FieldAttr(96)] public Vector4 _gravity; // TYPE_VECTOR4
        [FieldAttr(112)] public bool _enableContactCaching; // TYPE_BOOL
        [FieldAttr(113)] public bool _mergeEventsBeforeDispatch; // TYPE_BOOL
        [FieldAttr(114)] public ELeavingBroadPhaseBehavior _leavingBroadPhaseBehavior; // TYPE_ENUM, etype: LeavingBroadPhaseBehavior, subtype: TYPE_UINT8
        [FieldAttr(128)] public Vector4 _min; // TYPE_VECTOR4, (Inlined from type: hkAabb)
        [FieldAttr(144)] public Vector4 _max; // TYPE_VECTOR4, (Inlined from type: hkAabb)
        [FieldAttr(160)] public hknpBroadPhaseConfig _broadPhaseConfig; // TYPE_POINTER, ctype: hknpBroadPhaseConfig, subtype: TYPE_STRUCT
        [FieldAttr(168)] public hknpCollisionFilter _collisionFilter; // TYPE_POINTER, ctype: hknpCollisionFilter, subtype: TYPE_STRUCT
        [FieldAttr(176)] public hknpShapeTagCodec _shapeTagCodec; // TYPE_POINTER, ctype: hknpShapeTagCodec, subtype: TYPE_STRUCT
        [FieldAttr(184)] public float _collisionTolerance; // TYPE_REAL
        [FieldAttr(188)] public float _relativeCollisionAccuracy; // TYPE_REAL
        [FieldAttr(192)] public bool _enableWeldingForDefaultObjects; // TYPE_BOOL
        [FieldAttr(193)] public bool _enableWeldingForCriticalObjects; // TYPE_BOOL
        [FieldAttr(196)] public float _solverTau; // TYPE_REAL
        [FieldAttr(200)] public float _solverDamp; // TYPE_REAL
        [FieldAttr(204)] public i32 _solverIterations; // TYPE_INT32
        [FieldAttr(208)] public i32 _solverMicrosteps; // TYPE_INT32
        [FieldAttr(212)] public float _defaultSolverTimestep; // TYPE_REAL
        [FieldAttr(216)] public float _maxApproachSpeedForHighQualitySolver; // TYPE_REAL
        [FieldAttr(220)] public bool _enableDeactivation; // TYPE_BOOL
        [FieldAttr(221)] public bool _deleteCachesOnDeactivation; // TYPE_BOOL
        [FieldAttr(224)] public i32 _largeIslandSize; // TYPE_INT32
        [FieldAttr(228)] public bool _enableSolverDynamicScheduling; // TYPE_BOOL
        [FieldAttr(232)] public i32 _contactSolverType; // TYPE_INT32
        [FieldAttr(236)] public float _unitScale; // TYPE_REAL
        [FieldAttr(240)] public bool _applyUnitScaleToStaticConstants; // TYPE_BOOL
    }
}