namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 32, align: 8)]
    public class igVscAngleBetweenVec3fAccessor : igVscFloatAccessor
    {
        [FieldAttr(nst: 24, ctr: 16)] public igVscVec3fAccessor? _vectorA;
        [FieldAttr(nst: 32, ctr: 24)] public igVscVec3fAccessor? _vectorB;
    }
}
