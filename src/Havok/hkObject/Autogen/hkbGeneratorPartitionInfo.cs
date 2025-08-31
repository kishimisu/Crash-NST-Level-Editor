using Alchemy;

namespace Havok
{
    [ObjectAttr(40)]
    public class hkbGeneratorPartitionInfo : hkObject
    {
        public override uint Hash => 0xc5cf46e6;

        [FieldAttr(0)] public u32 _boneMask_0; // TYPE_UINT32, arrsize: 8
        [FieldAttr(4)] public u32 _boneMask_1;
        [FieldAttr(8)] public u32 _boneMask_2;
        [FieldAttr(12)] public u32 _boneMask_3;
        [FieldAttr(16)] public u32 _boneMask_4;
        [FieldAttr(20)] public u32 _boneMask_5;
        [FieldAttr(24)] public u32 _boneMask_6;
        [FieldAttr(28)] public u32 _boneMask_7;
        [FieldAttr(32)] public u32 _partitionMask; // TYPE_UINT32, arrsize: 1
        [FieldAttr(36)] public i16 _numBones; // TYPE_INT16
        [FieldAttr(38)] public i16 _numMaxPartitions; // TYPE_INT16
    }
}