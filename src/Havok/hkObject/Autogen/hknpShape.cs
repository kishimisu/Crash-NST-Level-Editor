using Alchemy;

namespace Havok
{
    [ObjectAttr(48)]
    public class hknpShape : hkReferencedObject
    {
        public override uint Hash => 0xdb52aabb;

        [FieldAttr(16)] public u16 _flags; // TYPE_FLAGS, etype: FlagsEnum, subtype: TYPE_UINT16
        [FieldAttr(18)] public u8 _numShapeKeyBits; // TYPE_UINT8
        [FieldAttr(19)] public EEnum _dispatchType; // TYPE_ENUM, etype: Enum, subtype: TYPE_UINT8
        [FieldAttr(20)] public float _convexRadius; // TYPE_REAL
        [FieldAttr(24)] public u64 _userData; // TYPE_UINT64
        [FieldAttr(32)] public hkRefCountedProperties _properties; // TYPE_POINTER, ctype: hkRefCountedProperties, subtype: TYPE_STRUCT
    }
}