namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class igBaseVertexArray : igObject
    {
        [FieldAttr(16)] public uint _cacheFlushSequenceId;
        [FieldAttr(20)] public uint _vertexCount;
        [FieldAttr(24)] public igRawRefMetaField _vertexCountArray = new();
        [FieldAttr(32)] public uint _vertexCounts;
        [FieldAttr(40)] public igVertexFormat? _format;
        [FieldAttr(48)] public EIG_GFX_DRAW _primitiveType;
        [FieldAttr(56)] public igMemoryRef<u8> _packData = new();
        [FieldAttr(72)] public uint _size;
        [FieldAttr(80)] public igVertexBuffer? _buffer;
        [FieldAttr(88)] public igRawRefMetaField _platformBuffer = new();
        [FieldAttr(96, false)] public igVertexArray? _softwareBlendedArray;
        [FieldAttr(104)] public uint _softwareBlendedSequenceId;
        [FieldAttr(108)] public bool _skinned;
        [FieldAttr(109)] public bool _transient;
    }
}
