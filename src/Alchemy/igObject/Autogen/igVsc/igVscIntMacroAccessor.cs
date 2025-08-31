namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscIntMacroAccessor : igVscIntAccessor
    {
        [FieldAttr(24, false)] public igObjectRefMetaFieldInstance? _accessorMetaField;
        [FieldAttr(32)] public int _default;
    }
}
