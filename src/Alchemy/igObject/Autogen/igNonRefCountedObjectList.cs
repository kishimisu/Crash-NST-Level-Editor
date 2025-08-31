namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igNonRefCountedObjectList : igDataList
    {
        [FieldAttr(24, false)] public igMemoryRef<igObject> _data = new();
    }
}
