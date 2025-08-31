namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscMultiplyFloatAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVscFloatAccessor? _a;
        [FieldAttr(32)] public igVscFloatAccessor? _b;
    }
}
