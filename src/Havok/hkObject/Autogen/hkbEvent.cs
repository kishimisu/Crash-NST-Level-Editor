using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkbEvent : hkbEventBase
    {
        public override uint Hash => 0x3e0fd810;

        [FieldAttr(16)] public u32 _sender; // TYPE_POINTER, flags: SERIALIZE_IGNORED
    }
}