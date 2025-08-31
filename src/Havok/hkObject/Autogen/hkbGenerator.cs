using Alchemy;

namespace Havok
{
    [ObjectAttr(136)]
    public class hkbGenerator : hkbNode
    {
        public override uint Hash => 0xad634f7e;

        [FieldAttr(80)] public hkbGeneratorPartitionInfo _partitionInfo; // TYPE_STRUCT, ctype: hkbGeneratorPartitionInfo, flags: SERIALIZE_IGNORED
        [FieldAttr(120)] public u32 _syncInfo; // TYPE_POINTER, flags: SERIALIZE_IGNORED
    }
}