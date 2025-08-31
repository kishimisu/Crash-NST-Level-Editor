using Alchemy;

namespace Havok
{
    [ObjectAttr(104)]
    public class hkxVertexBufferVertexData : hkObject
    {
        public override uint Hash => 0x427c01f4;

        [FieldAttr(0)] public hkMemory<u32> _vectorData; // TYPE_ARRAY, subtype: TYPE_UINT32
        [FieldAttr(16)] public hkMemory<u32> _floatData; // TYPE_ARRAY, subtype: TYPE_UINT32
        [FieldAttr(32)] public hkMemory<u32> _uint32Data; // TYPE_ARRAY, subtype: TYPE_UINT32
        [FieldAttr(48)] public hkMemory<u16> _uint16Data; // TYPE_ARRAY, subtype: TYPE_UINT16
        [FieldAttr(64)] public hkMemory<u8> _uint8Data; // TYPE_ARRAY, subtype: TYPE_UINT8
        [FieldAttr(80)] public u32 _numVerts; // TYPE_UINT32
        [FieldAttr(84)] public u32 _vectorStride; // TYPE_UINT32
        [FieldAttr(88)] public u32 _floatStride; // TYPE_UINT32
        [FieldAttr(92)] public u32 _uint32Stride; // TYPE_UINT32
        [FieldAttr(96)] public u32 _uint16Stride; // TYPE_UINT32
        [FieldAttr(100)] public u32 _uint8Stride; // TYPE_UINT32
    }
}