using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkBitField : hkObject
    {
        public override uint Hash => 0xe5dbbb9c;

        [FieldAttr(0)] public hkMemory<u32> _words; // TYPE_ARRAY, subtype: TYPE_UINT32
        [FieldAttr(16)] public i32 _numBits; // TYPE_INT32
    }
}