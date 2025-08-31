namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscEnumFieldAccessor : igVscEnumAccessor
    {
        [FieldAttr(24, false)] public igEnumMetaFieldInstance? _metaField;
    }
}
