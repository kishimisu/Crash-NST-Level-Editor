namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscIndexedVec2fFloatAccessor : igVscFloatAccessor
    {
        [FieldAttr(24)] public igVscVec2fAccessor? _vector;
        [FieldAttr(32)] public int _index;
    }
}
