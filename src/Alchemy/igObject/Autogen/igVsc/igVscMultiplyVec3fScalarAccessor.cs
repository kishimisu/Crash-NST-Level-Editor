namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscMultiplyVec3fScalarAccessor : igVscVec3fAccessor
    {
        [FieldAttr(24)] public igVscVec3fAccessor? _a;
        [FieldAttr(32)] public igVscFloatAccessor? _b;
    }
}
