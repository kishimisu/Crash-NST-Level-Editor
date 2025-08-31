using Alchemy;

namespace Havok
{
    [ObjectAttr(176)]
    public class hkaSplineCompressedAnimation : hkaAnimation
    {
        public override uint Hash => 0x8c3b5f7e;

        [FieldAttr(56)] public i32 _numFrames; // TYPE_INT32
        [FieldAttr(60)] public i32 _numBlocks; // TYPE_INT32
        [FieldAttr(64)] public i32 _maxFramesPerBlock; // TYPE_INT32
        [FieldAttr(68)] public i32 _maskAndQuantizationSize; // TYPE_INT32
        [FieldAttr(72)] public float _blockDuration; // TYPE_REAL
        [FieldAttr(76)] public float _blockInverseDuration; // TYPE_REAL
        [FieldAttr(80)] public float _frameDuration; // TYPE_REAL
        [FieldAttr(88)] public hkMemory<u32> _blockOffsets; // TYPE_ARRAY, subtype: TYPE_UINT32
        [FieldAttr(104)] public hkMemory<u32> _floatBlockOffsets; // TYPE_ARRAY, subtype: TYPE_UINT32
        [FieldAttr(120)] public hkMemory<u32> _transformOffsets; // TYPE_ARRAY, subtype: TYPE_UINT32
        [FieldAttr(136)] public hkMemory<u32> _floatOffsets; // TYPE_ARRAY, subtype: TYPE_UINT32
        [FieldAttr(152)] public hkMemory<u8> _data; // TYPE_ARRAY, subtype: TYPE_UINT8
        [FieldAttr(168)] public i32 _endian; // TYPE_INT32
    }
}