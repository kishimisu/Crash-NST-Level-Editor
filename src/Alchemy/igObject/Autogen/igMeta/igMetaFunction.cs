namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igMetaFunction : igObject
    {
        [FieldAttr(16)] public string? _functionName = null;
        [FieldAttr(24)] public u32 /* igStructMetaField */ _functionPointer;
        [FieldAttr(56)] public igObject? _attributes;
        [FieldAttr(64)] public igObject? _parameters;
        [FieldAttr(72)] public u32 /* igStructMetaField */ _properties;
    }
}
