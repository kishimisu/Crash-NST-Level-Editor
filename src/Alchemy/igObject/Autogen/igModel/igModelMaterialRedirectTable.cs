namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igModelMaterialRedirectTable : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<igHandleMetaField> _sourceHandles = new();
        [FieldAttr(40)] public igVectorMetaField<igHandleMetaField> _targetHandles = new();
        [FieldAttr(64)] public igHandleMetaField _defaultRedirectHandle = new();
    }
}
