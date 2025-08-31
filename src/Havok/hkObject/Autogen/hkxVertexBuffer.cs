using Alchemy;

namespace Havok
{
    [ObjectAttr(136)]
    public class hkxVertexBuffer : hkReferencedObject
    {
        public override uint Hash => 0xc7213b44;

        [FieldAttr(16)] public hkxVertexBufferVertexData _data; // TYPE_STRUCT, ctype: hkxVertexBufferVertexData
        [FieldAttr(120)] public hkxVertexDescription _desc; // TYPE_STRUCT, ctype: hkxVertexDescription
    }
}