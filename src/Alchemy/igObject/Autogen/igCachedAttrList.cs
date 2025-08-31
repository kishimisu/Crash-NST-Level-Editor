namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igCachedAttrList : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<igAttr> _attrs = new();
        [FieldAttr(40)] public igVectorMetaField<i16> _cachedValues = new();
    }
}
