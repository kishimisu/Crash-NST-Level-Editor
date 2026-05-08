namespace Alchemy
{
    [ObjectAttr(nst: 72, align: 8)]
    public class igFileDescriptor : igObject
    {
        [FieldAttr(nst: 16)] public string? _path = null;
        [FieldAttr(nst: 24)] public u64 _position;
        [FieldAttr(nst: 32)] public u64 _size;
        [FieldAttr(nst: 40, refCount: false)] public igStorageDevice? _device;
        [FieldAttr(nst: 48)] public igRawRefMetaField _handle = new();
        [FieldAttr(nst: 56)] public igSignal? _signal;
        [FieldAttr(nst: 64)] public uint _flags;
        [FieldAttr(nst: 68)] public int _workItemActiveCount;
    }
}
