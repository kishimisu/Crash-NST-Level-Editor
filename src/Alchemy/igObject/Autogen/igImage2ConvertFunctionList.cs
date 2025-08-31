namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igImage2ConvertFunctionList : igDataList
    {
        [FieldAttr(24)] public igMemoryRef<u32 /* igStructMetaField */> _data = new();
    }
}
