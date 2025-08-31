using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkaSkeletonLocalFrameOnBone : hkObject
    {
        public override uint Hash => 0xe9151edc;

        [FieldAttr(0)] public hkLocalFrame _localFrame; // TYPE_POINTER, ctype: hkLocalFrame, subtype: TYPE_STRUCT
        [FieldAttr(8)] public i16 _boneIndex; // TYPE_INT16
    }
}