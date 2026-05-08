namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 96, align: 16)]
    public class igDataBindingEntity : igObject
    {
        [FieldAttr(nst: 16, ctr: 16, refCount: false)] public igObject? _object;
        [FieldAttr(nst: 24, ctr: 24)] public igHandleMetaField _objectHandle = new();
        [FieldAttr(nst: 32, ctr: 32)] public igMetaFieldInstance? _field;
        [FieldAttr(nst: 40, ctr: 40)] public string? _fieldName = null;
        [FieldAttr(nst: 48, ctr: 48)] public uint _constant = new();
        [FieldAttr(nst: 80, ctr: 80)] public igDataTransform? _transform;
    }
}
