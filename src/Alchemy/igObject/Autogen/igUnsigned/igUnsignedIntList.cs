namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igUnsignedIntList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<uint> _data = new();
    }
}
