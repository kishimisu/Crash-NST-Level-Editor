using Alchemy;

namespace Havok
{
    [ObjectAttr(352)]
    public class hkbClipGenerator : hkbGenerator
    {
        public override uint Hash => 0xd4cc9f6;

        [FieldAttr(136)] public string _animationBundleName; // TYPE_STRINGPTR
        [FieldAttr(144)] public string _animationName; // TYPE_STRINGPTR
        [FieldAttr(152)] public hkbClipTriggerArray _triggers; // TYPE_POINTER, ctype: hkbClipTriggerArray, subtype: TYPE_STRUCT
        [FieldAttr(160)] public u32 _userPartitionMask; // TYPE_UINT32
        [FieldAttr(164)] public float _cropStartAmountLocalTime; // TYPE_REAL
        [FieldAttr(168)] public float _cropEndAmountLocalTime; // TYPE_REAL
        [FieldAttr(172)] public float _startTime; // TYPE_REAL
        [FieldAttr(176)] public float _playbackSpeed; // TYPE_REAL
        [FieldAttr(180)] public float _enforcedDuration; // TYPE_REAL
        [FieldAttr(184)] public float _userControlledTimeFraction; // TYPE_REAL
        [FieldAttr(188)] public i16 _animationBindingIndex; // TYPE_INT16
        [FieldAttr(190)] public EPlaybackMode _mode; // TYPE_ENUM, etype: PlaybackMode, subtype: TYPE_INT8
        [FieldAttr(191)] public i8 _flags; // TYPE_INT8
        [FieldAttr(192)] public hkMemory<u32> _animDatas; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(208)] public u32 _animationControl; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(216)] public u32 _originalTriggers; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(224)] public u32 _mapperData; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(232)] public u32 _binding; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(240)] public i32 _numAnimationTracks; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(256)] public Matrix3x4 _extractedMotion; // TYPE_QSTRANSFORM, flags: SERIALIZE_IGNORED
        [FieldAttr(304)] public hkMemory<u32> _echos; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(320)] public float _localTime; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(324)] public float _time; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(328)] public float _previousUserControlledTimeFraction; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(332)] public i32 _bufferSize; // TYPE_INT32, flags: SERIALIZE_IGNORED
        [FieldAttr(336)] public bool _atEnd; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(337)] public bool _ignoreStartTime; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(338)] public bool _pingPongBackward; // TYPE_BOOL, flags: SERIALIZE_IGNORED
    }
}