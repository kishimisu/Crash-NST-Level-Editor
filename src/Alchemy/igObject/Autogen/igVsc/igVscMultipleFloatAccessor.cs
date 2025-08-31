namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscMultipleFloatAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVectorMetaField<igVscAccessor> _accessors = new();
    }
}
