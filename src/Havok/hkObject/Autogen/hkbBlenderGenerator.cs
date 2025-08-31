using Alchemy;

namespace Havok
{
    [ObjectAttr(224)]
    public class hkbBlenderGenerator : hkbGenerator
    {
        public override uint Hash => 0xce45c088;

        [FieldAttr(136)] public float _referencePoseWeightThreshold; // TYPE_REAL
        [FieldAttr(140)] public float _blendParameter; // TYPE_REAL
        [FieldAttr(144)] public float _minCyclicBlendParameter; // TYPE_REAL
        [FieldAttr(148)] public float _maxCyclicBlendParameter; // TYPE_REAL
        [FieldAttr(152)] public i16 _indexOfSyncMasterChild; // TYPE_INT16
        [FieldAttr(154)] public i16 _flags; // TYPE_INT16
        [FieldAttr(156)] public bool _subtractLastChild; // TYPE_BOOL
        [FieldAttr(160)] public hkMemoryPtr<hkbBlenderGeneratorChild> _children; // TYPE_ARRAY, ctype: hkbBlenderGeneratorChild, subtype: TYPE_POINTER
        [FieldAttr(176)] public hkMemory<u32> _childrenInternalStates; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(192)] public hkMemory<u32> _sortedChildren; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(208)] public float _endIntervalWeight; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(212)] public i32 _numActiveChildren; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(216)] public i16 _beginIntervalIndex; // TYPE_INT16, flags: SERIALIZE_IGNORED
        [FieldAttr(218)] public i16 _endIntervalIndex; // TYPE_INT16, flags: SERIALIZE_IGNORED
        [FieldAttr(220)] public bool _initSync; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(221)] public bool _doSubtractiveBlend; // TYPE_BOOL, flags: SERIALIZE_IGNORED
    }
}