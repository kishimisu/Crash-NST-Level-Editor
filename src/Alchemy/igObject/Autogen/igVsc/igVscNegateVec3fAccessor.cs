namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igVscNegateVec3fAccessor : igVscVec3fAccessor
    {
        [FieldAttr(24)] public igVscVec3fAccessor? _value;
    }
}
