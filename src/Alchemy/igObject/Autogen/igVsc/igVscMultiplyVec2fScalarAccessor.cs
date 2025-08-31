namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscMultiplyVec2fScalarAccessor : igVscVec2fAccessor
    {
        [FieldAttr(24)] public igVscVec2fAccessor? _a;
        [FieldAttr(32)] public igVscFloatAccessor? _b;
    }
}
