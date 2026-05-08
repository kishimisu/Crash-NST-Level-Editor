namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 8)]
    public class igBufferedFile : igFile
    {
        [FieldAttr(nst: 40, ctr: 36)] public igFile.EMode _lastOperation;
        [FieldAttr(nst: 48, ctr: 40)] public igMemoryRef<u8> _buffer = new();
        [FieldAttr(nst: 64, ctr: 56)] public i64 _bufferPos;
        [FieldAttr(nst: 72, ctr: 64)] public i64 _bufferLen;
        [FieldAttr(nst: 80, ctr: 72)] public uint _mode;
    }
}
