namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscLogicalANDAccessor : igVscBoolAccessor
    {
        [FieldAttr(24)] public igVscBoolAccessor? _a;
        [FieldAttr(32)] public igVscBoolAccessor? _b;
    }
}
