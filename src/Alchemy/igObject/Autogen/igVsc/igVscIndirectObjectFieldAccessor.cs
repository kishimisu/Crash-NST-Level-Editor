namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscIndirectObjectFieldAccessor : igVscObjectAccessor
    {
        [FieldAttr(24, false)] public igRefMetaFieldInstance? _metaField;
        [FieldAttr(32)] public igVscObjectAccessor? _object;
    }
}
