namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscObjectFieldAccessor : igVscObjectAccessor
    {
        [FieldAttr(24, false)] public igRefMetaFieldInstance? _metaField;
    }
}
