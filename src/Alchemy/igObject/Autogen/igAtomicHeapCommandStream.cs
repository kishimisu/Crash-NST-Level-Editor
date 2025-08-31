namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class igAtomicHeapCommandStream : igCommandStream
    {
        [FieldAttr(64)] public igRawRefMetaField _head = new();
        [FieldAttr(72)] public int _chunkSize;
        [FieldAttr(80)] public igRawRefMetaField _heap = new();
    }
}
