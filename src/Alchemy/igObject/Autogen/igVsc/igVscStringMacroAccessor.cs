namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscStringMacroAccessor : igVscStringAccessor
    {
        [FieldAttr(24, false)] public igObjectRefMetaFieldInstance? _accessorMetaField;
        [FieldAttr(32)] public string? _default = null;
    }
}
