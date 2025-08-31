namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igGraphicsIndexBuffer : igGraphicsObject
    {
        [FieldAttr(24)] public EigResourceUsage _usage;
        [FieldAttr(32)] public igIndexBuffer? _indexBuffer;
        [FieldAttr(40)] public igSizeTypeMetaField _resource = new();
    }
}
