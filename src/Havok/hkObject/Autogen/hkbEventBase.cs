using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkbEventBase : hkObject
    {
        public override uint Hash => 0x76bddb31;

        [FieldAttr(0)] public i32 _id; // TYPE_INT32
        [FieldAttr(8)] public hkbEventPayload _payload; // TYPE_POINTER, ctype: hkbEventPayload, subtype: TYPE_STRUCT
    }
}