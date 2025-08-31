namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igFullScreenQuadDrawCall : igDrawCall
    {
        [FieldAttr(24)] public igVertexBuffer? _vertexBuffer;
        [FieldAttr(32)] public igSizeTypeMetaField _vertexBufferResource = new();
        [FieldAttr(40)] public igSizeTypeMetaField _vertexFormatResource = new();
        [FieldAttr(48)] public int _primitiveCount;
        [FieldAttr(56)] public igGraphicsMaterial? _material;
    }
}
