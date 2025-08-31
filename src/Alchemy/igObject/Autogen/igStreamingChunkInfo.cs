namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igStreamingChunkInfo : igInfo
    {
        [FieldAttr(40)] public igVectorMetaField<ChunkFileInfoMetaField> _required = new();
    }
}
