using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(160)]
    public class hknpCharacterRigidBodyCinfo : hkReferencedObject
    {
        public override uint Hash => 0x4979c225;

        [FieldAttr(16)] public u32 _collisionFilterInfo; // TYPE_UINT32
        [FieldAttr(24)] public hknpShape _shape; // TYPE_POINTER, ctype: hknpShape, subtype: TYPE_STRUCT
        [FieldAttr(32)] public u32 _world; // TYPE_POINTER, flags: SERIALIZE_IGNORED
        [FieldAttr(48)] public Vector4 _position; // TYPE_VECTOR4
        [FieldAttr(64)] public Quaternion _orientation; // TYPE_QUATERNION
        [FieldAttr(80)] public float _mass; // TYPE_REAL
        [FieldAttr(84)] public float _dynamicFriction; // TYPE_REAL
        [FieldAttr(88)] public float _staticFriction; // TYPE_REAL
        [FieldAttr(92)] public float _weldingTolerance; // TYPE_REAL
        [FieldAttr(96)] public u32 _reservedBodyId; // TYPE_UINT32
        [FieldAttr(100)] public u8 _additionMode; // TYPE_UINT8
        [FieldAttr(101)] public u8 _additionFlags; // TYPE_UINT8
        [FieldAttr(112)] public Vector4 _up; // TYPE_VECTOR4
        [FieldAttr(128)] public float _maxSlope; // TYPE_REAL
        [FieldAttr(132)] public float _maxForce; // TYPE_REAL
        [FieldAttr(136)] public float _maxSpeedForSimplexSolver; // TYPE_REAL
        [FieldAttr(140)] public float _supportDistance; // TYPE_REAL
        [FieldAttr(144)] public float _hardSupportDistance; // TYPE_REAL
    }
}