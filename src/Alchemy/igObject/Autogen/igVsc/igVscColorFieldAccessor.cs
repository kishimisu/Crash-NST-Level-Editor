namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscColorFieldAccessor : igVscColorAccessor
    {
        [FieldAttr(24, false)] public igVec4ucMetaFieldInstance? _metaField;
    }
}
