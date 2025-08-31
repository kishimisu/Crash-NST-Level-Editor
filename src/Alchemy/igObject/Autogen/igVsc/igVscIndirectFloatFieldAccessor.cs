namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscIndirectFloatFieldAccessor : igVscFloatAccessor
    {
        [FieldAttr(24, false)] public igFloatMetaFieldInstance? _metaField;
        [FieldAttr(32)] public igVscObjectAccessor? _object;
    }
}
