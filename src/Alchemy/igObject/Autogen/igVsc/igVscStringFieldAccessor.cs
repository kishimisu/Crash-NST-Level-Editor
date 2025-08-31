namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscStringFieldAccessor : igVscStringAccessor
    {
        [FieldAttr(24, false)] public igStringMetaFieldInstance? _metaField;
    }
}
