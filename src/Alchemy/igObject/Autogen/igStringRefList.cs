namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igStringRefList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<string?> _data = new();
    }
}
