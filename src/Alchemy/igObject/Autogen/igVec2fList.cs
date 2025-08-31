namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igVec2fList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<igVec2fMetaField> _data = new();
    }
}
