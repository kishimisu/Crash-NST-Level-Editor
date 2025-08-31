namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igGraphicsDepthStateBundle : igGraphicsObject
    {
        [FieldAttr(24)] public igDepthStateBundleDescMetaField _depthStateBundle = new();
        [FieldAttr(40)] public igSizeTypeMetaField _resource = new();
    }
}
