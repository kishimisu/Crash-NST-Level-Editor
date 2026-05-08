namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 128, align: 8)]
    public class igStream : igObject
    {
        [FieldAttr(nst: 16, ctr: 16, refCount: false)] public igStream? _thisPtr;
        [FieldAttr(nst: 24, ctr: 24)] public u8 _head = new();
        [FieldAttr(nst: 32, ctr: 32)] public u8 _currentHead = new();
        [FieldAttr(nst: 40, ctr: 40)] public int _chunkSize;
        [FieldAttr(nst: 48, ctr: 48)] public u8 _writeHead = new();
        [FieldAttr(nst: 56, ctr: 56)] public u8 _writeChunkBegin = new();
        [FieldAttr(nst: 64, ctr: 64)] public u8 _writeChunkEnd = new();
        [FieldAttr(nst: 72, ctr: 72)] public u8 _readHead = new();
        [FieldAttr(nst: 80, ctr: 80)] public u8 _readChunkBegin = new();
        [FieldAttr(nst: 88, ctr: 88)] public u8 _readChunkEnd = new();
        [FieldAttr(nst: 96, ctr: 96)] public igRawRefMetaField _heap = new();
        [FieldAttr(nst: 104, ctr: 104)] public igRawRefMetaField _localHeap = new();
        [FieldAttr(nst: 112, ctr: 112)] public bool _outOfMemory;
        [FieldAttr(nst: 116, ctr: 116)] public int _memoryUsedHighWater;
        [FieldAttr(nst: 120, ctr: 120)] public int _memoryAllocatedHighWater;
    }
}
