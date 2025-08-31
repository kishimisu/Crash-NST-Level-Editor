namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igNameList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<igNameMetaField> _data = new();
    }
}
