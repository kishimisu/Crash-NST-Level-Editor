namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscFloatFieldAccessor : igVscFloatAccessor
    {
        [FieldAttr(24, false)] public igFloatMetaFieldInstance? _metaField;
    }
}
