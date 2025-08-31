namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVec3fList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<igVec3fMetaField> _data = new();
    }
}
