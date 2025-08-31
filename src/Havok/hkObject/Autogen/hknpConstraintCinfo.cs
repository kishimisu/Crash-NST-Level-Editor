using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hknpConstraintCinfo : hkObject
    {
        public override uint Hash => 0x67ea986d;

        [FieldAttr(0)] public hkpConstraintData _constraintData; // TYPE_POINTER, ctype: hkpConstraintData, subtype: TYPE_STRUCT
        [FieldAttr(8)] public u32 _bodyA; // TYPE_UINT32
        [FieldAttr(12)] public u32 _bodyB; // TYPE_UINT32
        [FieldAttr(16)] public u8 _flags; // TYPE_FLAGS, etype: FlagsEnum, subtype: TYPE_UINT8
    }
}