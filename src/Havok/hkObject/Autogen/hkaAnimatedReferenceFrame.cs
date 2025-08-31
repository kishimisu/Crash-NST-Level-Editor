using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkaAnimatedReferenceFrame : hkReferencedObject
    {
        public override uint Hash => 0x985e4297;

        [FieldAttr(16)] public i8 _frameType; // TYPE_ENUM, subtype: TYPE_INT8, flags: SERIALIZE_IGNORED
    }
}