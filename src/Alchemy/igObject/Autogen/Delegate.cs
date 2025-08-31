namespace Alchemy
{
    [ObjectAttr(56, 8, metaObject: true)]
    public class Delegate : Object
    {
        [FieldAttr(32)] public igVectorMetaField<DelegateFunctionMetaField> _invocationList = new();
    }
}
