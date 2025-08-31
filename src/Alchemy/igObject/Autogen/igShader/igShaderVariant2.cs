namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class igShaderVariant2 : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<igSizeTypeMetaField> _resources = new();
        [FieldAttr(40)] public igVectorMetaField<igSizeTypeMetaField> _constants = new();
        [FieldAttr(64)] public igVectorMetaField<int> _variantSizes = new();
        [FieldAttr(88)] public igVectorMetaField<int> _elementIndices = new();
    }
}
