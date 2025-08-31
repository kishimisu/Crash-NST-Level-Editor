namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscFloatToIntAccessor : igVscIntAccessor
    {
        [FieldAttr(24)] public igVscFloatAccessor? _accessor;
    }
}
