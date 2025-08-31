namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igPickablePointLightDataList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<igPickablePointLightDataMetaField> _data = new();
    }
}
