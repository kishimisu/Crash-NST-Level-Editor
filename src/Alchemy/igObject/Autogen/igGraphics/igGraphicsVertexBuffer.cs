namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igGraphicsVertexBuffer : igGraphicsObject
    {
        [FieldAttr(24)] public EigResourceUsage _usage;
        [FieldAttr(32)] public igVertexBuffer? _vertexBuffer;
        [FieldAttr(40)] public igSizeTypeMetaField _bufferResource = new();
        [FieldAttr(48)] public igSizeTypeMetaField _formatResource = new();
    }
}
