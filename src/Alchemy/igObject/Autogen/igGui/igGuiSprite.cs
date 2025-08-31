namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igGuiSprite : igGuiAsset
    {
        [FieldAttr(32)] public igHandleMetaField _material = new();
        [FieldAttr(40, false)] public igSprite? _renderSprite;
        [FieldAttr(48)] public bool _imageSizeFromSource;
        [FieldAttr(52)] public float _imageWidth;
        [FieldAttr(56)] public float _imageHeight;
    }
}
