using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkReferencedObject : hkBaseObject
    {
        public override uint Hash => 0xb70c7949;

        [FieldAttr(8)] public u32 _memSizeAndRefCount; // TYPE_UINT32, flags: SERIALIZE_IGNORED
    }
}