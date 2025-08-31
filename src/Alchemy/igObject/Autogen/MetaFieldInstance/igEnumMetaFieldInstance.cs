namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igEnumMetaFieldInstance : igMetaFieldInstance
    {
        [FieldAttr(56, false)] public InlinedMemoryRef<igEnumMetaField> _default = new();
        [FieldAttr(72)] public igMetaEnum? _metaEnum;
    }
}
