using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkxVertexDescriptionElementDecl : hkObject
    {
        public override uint Hash => 0x865bf29f;

        [FieldAttr(0)] public u32 _byteOffset; // TYPE_UINT32
        [FieldAttr(4)] public EDataType _type; // TYPE_ENUM, etype: DataType, subtype: TYPE_UINT16
        [FieldAttr(6)] public EDataUsage _usage; // TYPE_ENUM, etype: DataUsage, subtype: TYPE_UINT16
        [FieldAttr(8)] public u32 _byteStride; // TYPE_UINT32
        [FieldAttr(12)] public u8 _numElements; // TYPE_UINT8
        [FieldAttr(16)] public string _channelID; // TYPE_STRINGPTR
    }
}