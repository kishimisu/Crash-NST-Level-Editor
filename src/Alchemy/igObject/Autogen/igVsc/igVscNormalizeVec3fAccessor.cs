namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscNormalizeVec3fAccessor : igVscVec3fAccessor
    {
        [FieldAttr(24)] public igVscVec3fAccessor? _vector;
    }
}
