namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CEntityComponent : igComponent
    {
        [ObjectAttr(1)]
        public class PropertyStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isInitialized;
            [FieldAttr(1, size: 1)] public bool _isPersistent;
        }

        [FieldAttr(40)] public PropertyStorage _propertyStorage = new();
    }
}
