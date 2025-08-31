namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CBoltedModelList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<CBoltedModelMetaField> _data = new();
    }
}
