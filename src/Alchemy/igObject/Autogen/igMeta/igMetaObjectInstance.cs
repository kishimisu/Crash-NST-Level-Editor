namespace Alchemy
{
    [ObjectAttr(152, 8)]
    public class igMetaObjectInstance : igObject
    {
        [FieldAttr(16)] public string? _name = null;
        [FieldAttr(24)] public igVectorMetaField<igMetaFieldInstance> _metaFields = new();
        [FieldAttr(48)] public int _instanceCount;
        [FieldAttr(56)] public igRawRefMetaField _vTablePointer = new();
        [FieldAttr(64, false)] public igMetaObjectInstance? _parent;
        [FieldAttr(72, false)] public igMetaObjectInstance? _lastChild;
        [FieldAttr(80, false)] public igMetaObjectInstance? _nextSibling;
        [FieldAttr(88)] public u16 _index = 65535;
        [FieldAttr(90)] public u16 _sizeofSize = 65535;
        [FieldAttr(92)] public u16 _properties;
        [FieldAttr(94)] public u16 _requiredAlignment = 4;
        [FieldAttr(96)] public u16 _dynamicFieldSize;
        [FieldAttr(98)] public u16 _requiredDynamicFieldAlignment = 4;
        [FieldAttr(104)] public igVectorMetaField<igMetaFunction> _metaFunctions = new();
        [FieldAttr(128)] public igObject? _attributes;
        [FieldAttr(136, false)] public igObject? _library;
        [FieldAttr(144)] public int _id = -1;
    }
}
