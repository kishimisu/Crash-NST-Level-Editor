namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igQuaternionfList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<igQuaternionfMetaField> _data = new();
    }
}
