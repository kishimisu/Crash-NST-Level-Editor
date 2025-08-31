using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(96)]
    public class hknpBodyCinfo : hkObject
    {
        public override uint Hash => 0x6896f7c9;

        [FieldAttr(0)] public hknpShape _shape; // TYPE_POINTER, ctype: hknpShape, subtype: TYPE_STRUCT
        [FieldAttr(8)] public u32 _reservedBodyId; // TYPE_UINT32
        [FieldAttr(12)] public u32 _motionId; // TYPE_UINT32
        [FieldAttr(16)] public u8 _qualityId; // TYPE_UINT8
        [FieldAttr(18)] public u16 _materialId; // TYPE_UINT16
        [FieldAttr(20)] public u32 _collisionFilterInfo; // TYPE_UINT32
        [FieldAttr(24)] public i32 _flags; // TYPE_INT32
        [FieldAttr(28)] public float _collisionLookAheadDistance; // TYPE_REAL
        [FieldAttr(32)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(40)] public u64 _userData; // TYPE_UINT64
        [FieldAttr(48)] public Vector4 _position; // TYPE_VECTOR4
        [FieldAttr(64)] public Quaternion _orientation; // TYPE_QUATERNION
        [FieldAttr(80)] public u8 _spuFlags; // TYPE_FLAGS, etype: SpuFlagsEnum, subtype: TYPE_UINT8
        [FieldAttr(88)] public hkLocalFrame _localFrame; // TYPE_POINTER, ctype: hkLocalFrame, subtype: TYPE_STRUCT
    }
}