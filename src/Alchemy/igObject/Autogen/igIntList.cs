namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igIntList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<int> _data = new();
    }
}
