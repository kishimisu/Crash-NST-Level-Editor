namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igRawRefAtomicLinearAllocator : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<igRawRefMetaField> _buffer = new();
        [FieldAttr(48)] public int _count;
    }
}
