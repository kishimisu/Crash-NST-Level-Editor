namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscDotVec3fAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVscVec3fAccessor? _vectorA;
        [FieldAttr(32)] public igVscVec3fAccessor? _vectorB;
    }
}
