namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igGraphicsBlendStateBundle : igGraphicsObject
    {
        [FieldAttr(24)] public igBlendStateBundleDescMetaField _blendStateBundle = new();
        [FieldAttr(64)] public igSizeTypeMetaField _resource = new();
    }
}
