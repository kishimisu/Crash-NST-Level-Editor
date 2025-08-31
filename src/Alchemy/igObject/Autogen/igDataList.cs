namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igDataList : igContainer
    {
        [FieldAttr(16)] public int _count;
        [FieldAttr(20)] public int _capacity;
    }
}
