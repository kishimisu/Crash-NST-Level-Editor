namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igVscMessageEntryPointNode : igVscEntryPointNode
    {
        [FieldAttr(56)] public igVectorMetaField<igMetaFieldInstance> _metaFields = new();
    }
}
