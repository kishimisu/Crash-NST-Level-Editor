namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 32, align: 8)]
    public class igDataTransform : igObject
    {
        [FieldAttr(nst: 16, ctr: 16, refCount: false)] public igMetaFieldInstance? _destinationType;
        [FieldAttr(nst: 24, ctr: 24, refCount: false)] public igMetaFieldInstance? _sourceType;
    }
}
