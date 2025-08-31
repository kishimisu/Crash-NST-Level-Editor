using Alchemy;

namespace Havok
{
    [ObjectAttr(4)]
    public class hkbEventInfo : hkObject
    {
        public override uint Hash => 0x5874eed4;

        [FieldAttr(0)] public u32 _flags; // TYPE_FLAGS, etype: Flags, subtype: TYPE_UINT32
    }
}