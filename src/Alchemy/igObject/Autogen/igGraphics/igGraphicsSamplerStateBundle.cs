namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igGraphicsSamplerStateBundle : igGraphicsObject
    {
        [FieldAttr(24)] public igSamplerStateBundleDescMetaField _samplerStateBundle = new();
        [FieldAttr(64)] public igSizeTypeMetaField _resource = new();
    }
}
