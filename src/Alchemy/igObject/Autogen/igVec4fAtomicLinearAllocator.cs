namespace Alchemy
{
    [ObjectAttr(64, 16)]
    public class igVec4fAtomicLinearAllocator : igObject
    {
        [FieldAttr(16)] public igVectorMetaField<igVec4fMetaField> _buffer = new();
        [FieldAttr(48)] public int _count;
    }
}
