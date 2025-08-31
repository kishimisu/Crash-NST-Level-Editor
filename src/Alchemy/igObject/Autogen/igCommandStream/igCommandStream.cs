namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class igCommandStream : igObject
    {
        [FieldAttr(16)] public igRawRefMetaField _writeHead = new();
        [FieldAttr(24)] public igRawRefMetaField _writeChunkBegin = new();
        [FieldAttr(32)] public igRawRefMetaField _writeChunkEnd = new();
        [FieldAttr(40)] public igRawRefMetaField _readHead = new();
        [FieldAttr(48)] public igRawRefMetaField _readChunkBegin = new();
        [FieldAttr(56)] public igRawRefMetaField _readChunkEnd = new();
    }
}
