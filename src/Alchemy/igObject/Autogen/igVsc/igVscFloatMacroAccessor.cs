namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscFloatMacroAccessor : igVscFloatAccessor
    {
        [FieldAttr(24, false)] public igObjectRefMetaFieldInstance? _accessorMetaField;
        [FieldAttr(32)] public float _default;
    }
}
