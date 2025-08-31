namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscIndirectVec3fFieldAccessor : igVscVec3fAccessor
    {
        [FieldAttr(24, false)] public igVec3fMetaFieldInstance? _metaField;
        [FieldAttr(32)] public igVscObjectAccessor? _object;
    }
}
