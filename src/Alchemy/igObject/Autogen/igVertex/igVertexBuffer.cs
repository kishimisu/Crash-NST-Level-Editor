namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class igVertexBuffer : igObject
    {
        [FieldAttr(16)] public uint _vertexCount;
        [FieldAttr(24)] public igMemoryRef<uint> _vertexCountArray = new();
        [FieldAttr(40)] public igMemoryRef<u8> _data = new();
        [FieldAttr(56)] public igVertexFormat? _format;
        [FieldAttr(64)] public EIG_GFX_DRAW _primitiveType;
        [FieldAttr(72)] public igMemoryRef<u8> _packData = new();
        [FieldAttr(88, false)] public igVertexArray? _vertexArray;
        [FieldAttr(96)] public int _vertexArrayRefCount;
    }
}
