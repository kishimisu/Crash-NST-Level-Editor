namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igGraphicsRenderTargetMask : igGraphicsObject
    {
        [FieldAttr(24)] public igRenderTargetMaskDescMetaField _renderTargetMask = new();
        [FieldAttr(40)] public igSizeTypeMetaField _resource = new();
    }
}
