namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscIntToFloatAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVscIntAccessor? _accessor;
    }
}
