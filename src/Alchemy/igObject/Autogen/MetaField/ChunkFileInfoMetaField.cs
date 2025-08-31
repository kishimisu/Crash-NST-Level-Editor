namespace Alchemy
{
    [ObjectAttr(16, 16)]
    public class ChunkFileInfoMetaField : igCompoundMetaField
    {
        [FieldAttr(0)] public string? _type = null;
        [FieldAttr(8)] public string? _name = null;
    }
}
