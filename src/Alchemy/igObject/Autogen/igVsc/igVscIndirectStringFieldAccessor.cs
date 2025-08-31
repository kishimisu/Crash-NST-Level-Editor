namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscIndirectStringFieldAccessor : igVscStringAccessor
    {
        [FieldAttr(24, false)] public igStringMetaFieldInstance? _metaField;
        [FieldAttr(32)] public igVscObjectAccessor? _object;
    }
}
