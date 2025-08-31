namespace Alchemy
{
    [ObjectAttr(96, 16)]
    public class igPtrMemoryPool : igObject
    {
        [FieldAttr(16, false)] public igPtrMemoryPool? _thisPtr;
        [FieldAttr(24)] public igRawRefMetaField _head = new();
        [FieldAttr(32)] public uint _chunkSize;
        [FieldAttr(40)] public igRawRefMetaField _stackCurrent = new();
        [FieldAttr(48)] public igRawRefMetaField _stackBegin = new();
        [FieldAttr(56)] public igRawRefMetaField _stackEnd = new();
        [FieldAttr(64)] public igRawRefMetaField _heap = new();
        [FieldAttr(72)] public igRawRefMetaField _localHeap = new();
        [FieldAttr(80)] public bool _outOfMemory;
    }
}
