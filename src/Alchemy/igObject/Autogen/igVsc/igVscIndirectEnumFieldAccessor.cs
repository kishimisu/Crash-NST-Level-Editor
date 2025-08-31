namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscIndirectEnumFieldAccessor : igVscEnumAccessor
    {
        [FieldAttr(24, false)] public igEnumMetaFieldInstance? _metaField;
        [FieldAttr(32)] public igVscObjectAccessor? _object;
    }
}
