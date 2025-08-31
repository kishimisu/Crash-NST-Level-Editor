namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class igGraphicsStencilStateBundle : igGraphicsObject
    {
        [FieldAttr(24)] public igStencilStateBundleDescMetaField _stencilStateBundle = new();
        [FieldAttr(80)] public igSizeTypeMetaField _resource = new();
    }
}
