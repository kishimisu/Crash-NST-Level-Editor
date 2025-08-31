using Alchemy;

namespace Havok
{
    [ObjectAttr(96)]
    public class hkbLayer : hkbBindable
    {
        public override uint Hash => 0x2916a243;

        [FieldAttr(48)] public hkbGenerator _generator; // TYPE_POINTER, ctype: hkbGenerator, subtype: TYPE_STRUCT
        [FieldAttr(56)] public float _weight; // TYPE_REAL
        [FieldAttr(64)] public hkbBoneWeightArray _boneWeights; // TYPE_POINTER, ctype: hkbBoneWeightArray, subtype: TYPE_STRUCT
        [FieldAttr(72)] public float _fadeInDuration; // TYPE_REAL
        [FieldAttr(76)] public float _fadeOutDuration; // TYPE_REAL
        [FieldAttr(80)] public i32 _onEventId; // TYPE_INT32
        [FieldAttr(84)] public i32 _offEventId; // TYPE_INT32
        [FieldAttr(88)] public bool _onByDefault; // TYPE_BOOL
        [FieldAttr(89)] public bool _useMotion; // TYPE_BOOL
        [FieldAttr(90)] public bool _forceFullFadeDurations; // TYPE_BOOL
    }
}