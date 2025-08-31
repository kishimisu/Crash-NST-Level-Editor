namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igBoolList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<bool> _data = new();
    }
}
