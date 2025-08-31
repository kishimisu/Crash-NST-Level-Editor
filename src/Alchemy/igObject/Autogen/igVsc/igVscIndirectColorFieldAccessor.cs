namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscIndirectColorFieldAccessor : igVscColorAccessor
    {
        [FieldAttr(24, false)] public igVec4ucMetaFieldInstance? _metaField;
        [FieldAttr(32)] public igVscObjectAccessor? _object;
    }
}
