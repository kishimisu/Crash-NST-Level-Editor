using Alchemy;

namespace Havok
{
    [ObjectAttr(64)]
    public class hkxIndexBuffer : hkReferencedObject
    {
        public override uint Hash => 0x81d1cd6e;

        [FieldAttr(16)] public EIndexType _indexType; // TYPE_ENUM, etype: IndexType, subtype: TYPE_INT8
        [FieldAttr(24)] public hkMemory<u16> _indices16; // TYPE_ARRAY, subtype: TYPE_UINT16
        [FieldAttr(40)] public hkMemory<u32> _indices32; // TYPE_ARRAY, subtype: TYPE_UINT32
        [FieldAttr(56)] public u32 _vertexBaseOffset; // TYPE_UINT32
        [FieldAttr(60)] public u32 _length; // TYPE_UINT32
    }
}