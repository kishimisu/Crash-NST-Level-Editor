namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class igMetaEnum : igBaseMeta
    {
        [FieldAttr(24)] public bool _flags;
        [FieldAttr(32)] public igVectorMetaField<string?> _names = new();
        [FieldAttr(56)] public igVectorMetaField<int> _values = new();
        [FieldAttr(80)] public igObject? _attributes;
        [FieldAttr(88)] public igObject? _valueAttributes;
        [FieldAttr(96)] public string? _declaringType = null;
    }
}
