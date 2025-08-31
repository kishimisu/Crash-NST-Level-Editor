namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igObjectList : igObjectList<igObject> {}

    [ObjectAttr(40, 8)]
    public class igObjectList<T> : igDataList where T : igObject
    {
        [FieldAttr(24)] public igMemoryRef<T> _data = new(); 
    }
}