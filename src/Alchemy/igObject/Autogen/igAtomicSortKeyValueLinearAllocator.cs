namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igAtomicSortKeyValueLinearAllocator : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<igSortKeyValuePairMetaField> _buffer = new();
        [FieldAttr(48)] public int _count;
    }
}
