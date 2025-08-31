namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igUnsignedShortList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<u16> _data = new();
    }
}
