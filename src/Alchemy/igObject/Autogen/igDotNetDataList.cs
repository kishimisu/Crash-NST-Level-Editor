namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igDotNetDataList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<DotNetDataMetaField> _data = new();
    }
}
