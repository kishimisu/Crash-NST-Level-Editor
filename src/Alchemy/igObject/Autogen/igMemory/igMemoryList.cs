namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igMemoryList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<igMemoryRef> _data = new();
    }
}
