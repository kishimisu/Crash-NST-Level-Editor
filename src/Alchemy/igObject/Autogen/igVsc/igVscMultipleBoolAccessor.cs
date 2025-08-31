namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igVscMultipleBoolAccessor : igVscBoolAccessor
    {
        [FieldAttr(24)] public igVectorMetaField<igVscAccessor> _accessors = new();
    }
}
