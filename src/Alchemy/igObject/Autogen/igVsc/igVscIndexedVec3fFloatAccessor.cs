namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscIndexedVec3fFloatAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVscVec3fAccessor? _vector;
        [FieldAttr(32)] public int _index;
    }
}
