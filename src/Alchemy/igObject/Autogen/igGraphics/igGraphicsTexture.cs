namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igGraphicsTexture : igGraphicsObject
    {
        [FieldAttr(24)] public EigResourceUsage _usage;
        [FieldAttr(32)] public igImage2? _image;
        [FieldAttr(40)] public igHandleMetaField _imageHandle = new();
        [FieldAttr(48)] public igSizeTypeMetaField _resource = new();
    }
}
