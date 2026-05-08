namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 40, align: 8)]
    public class igDataBinding : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igDataBindingEntity? _destination;
        [FieldAttr(nst: 24, ctr: 24)] public igDataBindingEntity? _source;
        [FieldAttr(nst: 32, ctr: 32)] public igDataTransformList? _transformList;
    }
}
