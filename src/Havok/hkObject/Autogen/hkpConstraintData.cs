using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkpConstraintData : hkReferencedObject
    {
        public override uint Hash => 0x57339dd7;

        [FieldAttr(16)] public u64 _userData; // TYPE_ULONG
    }
}