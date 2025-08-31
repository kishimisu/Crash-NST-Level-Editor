namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscMultiplyScalarVec3fAccessor : igVscVec3fAccessor
    {
        [FieldAttr(24)] public igVscFloatAccessor? _a;
        [FieldAttr(32)] public igVscVec3fAccessor? _b;
    }
}
