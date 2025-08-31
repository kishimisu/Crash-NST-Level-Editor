using Alchemy;

namespace Havok
{
    [ObjectAttr(80)]
    public class hkbBlenderGeneratorChild : hkbBindable
    {
        public override uint Hash => 0xb35bbfd3;

        [FieldAttr(48)] public hkbGenerator _generator; // TYPE_POINTER, ctype: hkbGenerator, subtype: TYPE_STRUCT
        [FieldAttr(56)] public hkbBoneWeightArray _boneWeights; // TYPE_POINTER, ctype: hkbBoneWeightArray, subtype: TYPE_STRUCT
        [FieldAttr(64)] public float _weight; // TYPE_REAL
        [FieldAttr(68)] public float _worldFromModelWeight; // TYPE_REAL
    }
}