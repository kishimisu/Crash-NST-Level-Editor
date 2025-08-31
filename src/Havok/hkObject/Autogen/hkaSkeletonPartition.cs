using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkaSkeletonPartition : hkObject
    {
        public override uint Hash => 0x7c8e6a55;

        [FieldAttr(0)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(8)] public i16 _startBoneIndex; // TYPE_INT16
        [FieldAttr(10)] public i16 _numBones; // TYPE_INT16
    }
}