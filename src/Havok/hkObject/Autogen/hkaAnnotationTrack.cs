using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkaAnnotationTrack : hkObject
    {
        public override uint Hash => 0xd4114fdd;

        [FieldAttr(0)] public string _trackName; // TYPE_STRINGPTR
        [FieldAttr(8)] public hkMemory<hkaAnnotationTrackAnnotation> _annotations; // TYPE_ARRAY, ctype: hkaAnnotationTrackAnnotation, subtype: TYPE_STRUCT
    }
}