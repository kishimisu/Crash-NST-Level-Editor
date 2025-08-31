namespace Alchemy
{
    [ObjectAttr(32, 16)]
    public class igGuiAsset : igObject
    {
        [FieldAttr(16)] public string? _name = null;
        [FieldAttr(24, false)] public igGuiAsset? _sourceAsset;
    }
}
