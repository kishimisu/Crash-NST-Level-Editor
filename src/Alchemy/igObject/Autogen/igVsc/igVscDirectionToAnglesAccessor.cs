namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVscDirectionToAnglesAccessor : igVscVec3fAccessor
    {
        [FieldAttr(24)] public igVscVec3fAccessor? _vector;
        [FieldAttr(32)] public igVscBoolAccessor? _normalize;
    }
}
