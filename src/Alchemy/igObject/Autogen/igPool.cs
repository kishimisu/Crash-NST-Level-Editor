namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class igPool : igObject
    {
        [FieldAttr(16)] public bool _fixed;
        [FieldAttr(17)] public bool _autoRefCount;
        [FieldAttr(20)] public uint _capacity;
        [FieldAttr(24)] public uint _peakAllocatedCount;
        [FieldAttr(32)] public igPoolBucket? _bucket;
        [FieldAttr(40)] public igIndexPool? _indices;
        [FieldAttr(48, false)] public igMemoryPool? _dataPool;
        [FieldAttr(56)] public u16 _elementSize;
        [FieldAttr(58)] public u16 _elementAlignment;
        [FieldAttr(64)] public igMutex? _lock;
        [FieldAttr(72)] public igMetaObject? _typeOverride;
    }
}
