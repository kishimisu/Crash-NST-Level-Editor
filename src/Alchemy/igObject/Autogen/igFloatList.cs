namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igFloatList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<float> _data = new();
    }
}
