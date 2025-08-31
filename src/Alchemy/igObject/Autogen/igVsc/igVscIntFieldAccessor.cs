namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscIntFieldAccessor : igVscIntAccessor
    {
        [FieldAttr(24, false)] public igIntMetaFieldInstance? _metaField;
    }
}
