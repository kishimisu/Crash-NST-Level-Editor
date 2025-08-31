using Alchemy;

namespace Havok
{
    [ObjectAttr(136)]
    public class hkaSkeleton : hkReferencedObject
    {
        public override uint Hash => 0xfec1cedb;

        [FieldAttr(16)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(24)] public hkMemory<i16> _parentIndices; // TYPE_ARRAY, subtype: TYPE_INT16
        [FieldAttr(40)] public hkMemory<hkaBone> _bones; // TYPE_ARRAY, ctype: hkaBone, subtype: TYPE_STRUCT
        [FieldAttr(56)] public hkMemory<Matrix3x4> _referencePose; // TYPE_ARRAY, subtype: TYPE_QSTRANSFORM
        [FieldAttr(72)] public hkMemory<float> _referenceFloats; // TYPE_ARRAY, subtype: TYPE_REAL
        [FieldAttr(88)] public hkMemory<string> _floatSlots; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(104)] public hkMemory<hkaSkeletonLocalFrameOnBone> _localFrames; // TYPE_ARRAY, ctype: hkaSkeletonLocalFrameOnBone, subtype: TYPE_STRUCT
        [FieldAttr(120)] public hkMemory<hkaSkeletonPartition> _partitions; // TYPE_ARRAY, ctype: hkaSkeletonPartition, subtype: TYPE_STRUCT
    }
}