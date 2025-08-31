namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscMultiplyFloatIntAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVscFloatAccessor? _a;
        [FieldAttr(32)] public igVscIntAccessor? _b;
    }
}
