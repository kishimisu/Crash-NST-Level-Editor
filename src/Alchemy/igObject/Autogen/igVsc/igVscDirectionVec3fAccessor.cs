namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 8)]
    public class igVscDirectionVec3fAccessor : igVscVec3fAccessor
    {
        [FieldAttr(nst: 24, ctr: 16)] public igVscVec3fAccessor? _fromPosition;
        [FieldAttr(nst: 32, ctr: 24)] public igVscVec3fAccessor? _toPosition;
        [FieldAttr(nst: 40, ctr: 32)] public igVscBoolAccessor? _normalize;
    }
}
