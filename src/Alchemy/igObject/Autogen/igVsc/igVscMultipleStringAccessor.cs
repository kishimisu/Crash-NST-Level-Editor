namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscMultipleStringAccessor : igVscStringAccessor
    {
        [FieldAttr(24)] public igVectorMetaField<igVscAccessor> _accessors = new();
    }
}
