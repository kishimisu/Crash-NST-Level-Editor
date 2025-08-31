using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hknpBodyQuality : hkObject
    {
        public override uint Hash => 0x4d0fbd5b;

        [FieldAttr(0)] public i32 _priority; // TYPE_INT32
        [FieldAttr(4)] public u32 _supportedFlags; // TYPE_FLAGS, etype: FlagsEnum, subtype: TYPE_UINT32
        [FieldAttr(8)] public u32 _requestedFlags; // TYPE_FLAGS, etype: FlagsEnum, subtype: TYPE_UINT32
        [FieldAttr(12)] public float _contactCachingRelativeMovementThreshold; // TYPE_REAL
    }
}