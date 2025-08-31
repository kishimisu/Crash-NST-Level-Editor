namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscDivideIntFloatAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVscIntAccessor? _a;
        [FieldAttr(32)] public igVscFloatAccessor? _b;
    }
}
