namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class igMemoryCommandStream : igCommandStream
    {
        [FieldAttr(64)] public igMemoryRef<u8> _memory = new();
        [FieldAttr(80)] public uint _bytesWritten;
    }
}
