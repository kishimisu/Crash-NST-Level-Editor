using Alchemy;

namespace Havok
{
    [ObjectAttr(56)]
    public class hkaAnimation : hkReferencedObject
    {
        public override uint Hash => 0xb545fe18;

        [FieldAttr(16)] public EAnimationType _type; // TYPE_ENUM, etype: AnimationType, subtype: TYPE_INT32
        [FieldAttr(20)] public float _duration; // TYPE_REAL
        [FieldAttr(24)] public i32 _numberOfTransformTracks; // TYPE_INT32
        [FieldAttr(28)] public i32 _numberOfFloatTracks; // TYPE_INT32
        [FieldAttr(32)] public hkaAnimatedReferenceFrame _extractedMotion; // TYPE_POINTER, ctype: hkaAnimatedReferenceFrame, subtype: TYPE_STRUCT
        [FieldAttr(40)] public hkMemory<hkaAnnotationTrack> _annotationTracks; // TYPE_ARRAY, ctype: hkaAnnotationTrack, subtype: TYPE_STRUCT
    }
}