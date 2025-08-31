namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscBoolFieldAccessor : igVscBoolAccessor
    {
        [FieldAttr(24, false)] public igBoolMetaFieldInstance? _metaField;
    }
}
