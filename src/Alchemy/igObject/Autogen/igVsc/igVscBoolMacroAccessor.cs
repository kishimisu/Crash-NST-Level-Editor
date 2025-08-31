namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscBoolMacroAccessor : igVscBoolAccessor
    {
        [FieldAttr(24, false)] public igObjectRefMetaFieldInstance? _accessorMetaField;
        [FieldAttr(32)] public bool _default;
    }
}
