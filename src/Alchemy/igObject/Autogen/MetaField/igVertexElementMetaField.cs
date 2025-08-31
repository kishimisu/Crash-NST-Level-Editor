namespace Alchemy
{
    [ObjectAttr(12, 8)]
    public class igVertexElementMetaField : igCompoundMetaField
    {
        [FieldAttr(0)] public u8 _type;
        [FieldAttr(1)] public u8 _stream;
        [FieldAttr(2)] public u8 _mapToElement;
        [FieldAttr(3)] public u8 _count;
        [FieldAttr(4)] public u8 _usage;
        [FieldAttr(5)] public u8 _usageIndex;
        [FieldAttr(6)] public u8 _packDataOffset;
        [FieldAttr(7)] public u8 _packTypeAndFracHint;
        [FieldAttr(8)] public u16 _offset;
        [FieldAttr(10)] public u16 _freq;
    }
}
