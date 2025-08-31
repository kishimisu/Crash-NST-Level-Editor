namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscIndirectBoolFieldAccessor : igVscBoolAccessor
    {
        [FieldAttr(24, false)] public igBoolMetaFieldInstance? _metaField;
        [FieldAttr(32)] public igVscObjectAccessor? _object;
    }
}
