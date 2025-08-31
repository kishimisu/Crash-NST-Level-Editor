namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igRawRefList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<igRawRefMetaField> _data = new();
    }
}
