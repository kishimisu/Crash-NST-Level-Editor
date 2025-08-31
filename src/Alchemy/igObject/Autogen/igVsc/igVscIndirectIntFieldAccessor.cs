namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscIndirectIntFieldAccessor : igVscIntAccessor
    {
        [FieldAttr(24, false)] public igIntMetaFieldInstance? _metaField;
        [FieldAttr(32)] public igVscObjectAccessor? _object;
    }
}
