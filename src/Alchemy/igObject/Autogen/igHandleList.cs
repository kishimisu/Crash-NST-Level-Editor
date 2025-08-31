namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igHandleList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<igHandleMetaField> _data = new();
    }
}
