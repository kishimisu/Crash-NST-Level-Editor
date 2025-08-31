namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igBaseIndexArray : igObject
    {
        [FieldAttr(16)] public uint _indexCount;
        [FieldAttr(24)] public igRawRefMetaField _indexCountArray = new();
        [FieldAttr(32)] public uint _indexCounts;
        [FieldAttr(40)] public igIndexFormat? _format;
        [FieldAttr(48)] public EIG_GFX_DRAW _primitiveType;
        [FieldAttr(52)] public uint _size;
        [FieldAttr(56)] public igIndexBuffer? _buffer;
        [FieldAttr(64)] public igRawRefMetaField _platformBuffer = new();
        [FieldAttr(72)] public u32 /* igStructMetaField */ _vertexFormat;
    }
}
