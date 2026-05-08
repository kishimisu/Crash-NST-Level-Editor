namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 88, align: 8)]
    public class igMemoryCommandStream : igCommandStream
    {
        [FieldAttr(nst: 64, ctr: 64)] public igMemoryRef<u8> _memory = new();
        [FieldAttr(nst: 80, ctr: 80)] public uint _bytesWritten;
    }
}
