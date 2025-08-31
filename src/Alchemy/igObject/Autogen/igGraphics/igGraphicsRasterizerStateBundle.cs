namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igGraphicsRasterizerStateBundle : igGraphicsObject
    {
        [FieldAttr(24)] public igRasterizerStateBundleDescMetaField _rasterizerStateBundle = new();
        [FieldAttr(56)] public igSizeTypeMetaField _resource = new();
    }
}
