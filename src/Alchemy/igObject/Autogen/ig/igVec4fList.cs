namespace Alchemy
{
    [ObjectAttr(nst: 40, ctr: 40, align: 8)]
    public class igVec4fList : igDataList
    {
        [FieldAttr(nst: 24, ctr: 24)] public igMemoryRef<igVec4fMetaField> _data = new();
    }
}
