namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscDistanceBetweenVec3fAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVscVec3fAccessor? _positionA;
        [FieldAttr(32)] public igVscVec3fAccessor? _positionB;
    }
}
