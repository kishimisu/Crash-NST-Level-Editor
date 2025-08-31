namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igUnsignedCharList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<u8> _data = new();
    }
}
