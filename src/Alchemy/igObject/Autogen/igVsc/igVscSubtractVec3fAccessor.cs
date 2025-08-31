namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscSubtractVec3fAccessor : igVscVec3fAccessor
    {
        [FieldAttr(24)] public igVscVec3fAccessor? _a;
        [FieldAttr(32)] public igVscVec3fAccessor? _b;
    }
}
