namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igCompoundMetaFieldInstance : igMetaFieldInstance
    {
        [FieldAttr(56, false)] public igMemoryRef<igCompoundMetaField> _default = new();
        [FieldAttr(72)] public igMetaFieldList? _fieldList;
    }
}
