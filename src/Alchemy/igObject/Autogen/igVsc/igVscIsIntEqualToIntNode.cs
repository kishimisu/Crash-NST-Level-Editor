namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 48, align: 8)]
    public class igVscIsIntEqualToIntNode : igVscActionNode
    {
        [FieldAttr(nst: 16, ctr: 16)] public igVscIntAccessor? _a;
        [FieldAttr(nst: 24, ctr: 24)] public igVscIntAccessor? _b;
        [FieldAttr(nst: 32, ctr: 32)] public igVscBoolAccessor? _result;
        [FieldAttr(nst: 40, ctr: 40, refCount: false)] public igVscActionNode? _out;
    }
}
