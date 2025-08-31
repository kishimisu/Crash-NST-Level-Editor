namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscSubtractIntAccessor : igVscIntAccessor
    {
        [FieldAttr(24)] public igVscIntAccessor? _a;
        [FieldAttr(32)] public igVscIntAccessor? _b;
    }
}
