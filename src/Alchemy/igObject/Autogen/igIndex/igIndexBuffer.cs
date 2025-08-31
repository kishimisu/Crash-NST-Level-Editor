namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class igIndexBuffer : igObject
    {
        [FieldAttr(16)] public uint _indexCount;
        [FieldAttr(24)] public igMemoryRef<uint> _indexCountArray = new();
        [FieldAttr(40)] public igMemoryRef<u8> _data = new();
        [FieldAttr(56)] public igIndexFormat? _format;
        [FieldAttr(64)] public EIG_GFX_DRAW _primitiveType;
        [FieldAttr(72)] public igVertexFormat? _vertexFormat;
        [FieldAttr(80, false)] public igIndexArray2? _indexArray;
        [FieldAttr(88)] public int _indexArrayRefCount;
    }
}
