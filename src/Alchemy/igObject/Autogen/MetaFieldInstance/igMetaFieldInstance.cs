namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igMetaFieldInstance : igObject
    {
        [FieldAttr(16)] public u16 _parentMetaObjectIndex = 65535;
        [FieldAttr(18)] public i16 _typeIndex = -1;
        [FieldAttr(20)] public i16 _internalIndex = -1;
        [FieldAttr(22)] public u16 _size;
        [FieldAttr(24)] public u16 _offset;
        [FieldAttr(32)] public igObject? _attributes;
        [FieldAttr(40)] public u32 /* igStructMetaField */ _properties;
        [FieldAttr(48)] public string? _fieldName = null;
    }
}
