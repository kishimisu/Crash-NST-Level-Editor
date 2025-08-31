namespace Alchemy
{
    [ObjectAttr(152, 8)]
    public class igDynamicBuffer : igObject
    {
        [FieldAttr(16)] public igMemoryRef[] _buffer = new igMemoryRef[3];
        [FieldAttr(64)] public igSizeTypeMetaField[] _resource = new igSizeTypeMetaField[3];
        [FieldAttr(88)] public igDeferredDynamicBufferSwapMetaField[] _deferredSwap = new igDeferredDynamicBufferSwapMetaField[1];
        [FieldAttr(136)] public uint _deferredSwapIndex;
        [FieldAttr(140)] public uint _offset;
        [FieldAttr(144)] public uint _alignment;
        [FieldAttr(148)] public bool _tripleBuffer;
    }
}
