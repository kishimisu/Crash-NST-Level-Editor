namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 32, align: 8)]
    public class igVscMultiplyIntFloatAccessor : igVscFloatAccessor
    {
        [FieldAttr(nst: 24, ctr: 16)] public igVscIntAccessor? _a;
        [FieldAttr(nst: 32, ctr: 24)] public igVscFloatAccessor? _b;
    }
}
