using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkaMeshBindingMapping : hkObject
    {
        public override uint Hash => 0x48aceb75;

        [FieldAttr(0)] public hkMemory<i16> _mapping; // TYPE_ARRAY, subtype: TYPE_INT16
    }
}