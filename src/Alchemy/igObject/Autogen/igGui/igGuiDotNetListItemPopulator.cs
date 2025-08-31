namespace Alchemy
{
    [ObjectAttr(32, 8, metaObject: true)]
    public class igGuiDotNetListItemPopulator : igGuiListItemPopulator
    {
        [FieldAttr(16)] public igRawRefMetaField _dynamicFieldMemory = new();
        [FieldAttr(24, false)] public igMetaObject? _meta = (null);
    }
}
