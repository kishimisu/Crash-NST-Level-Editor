using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkaAnnotationTrackAnnotation : hkObject
    {
        public override uint Hash => 0x623bf34f;

        [FieldAttr(0)] public float _time; // TYPE_REAL
        [FieldAttr(8)] public string _text; // TYPE_STRINGPTR
    }
}