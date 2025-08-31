using Alchemy;

namespace Havok
{
    [ObjectAttr(80)]
    public class hknpMaterial : hkObject
    {
        public override uint Hash => 0xb7c5f24e;

        [FieldAttr(0)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(8)] public u32 _isExclusive; // TYPE_UINT32
        [FieldAttr(12)] public i32 _flags; // TYPE_INT32
        [FieldAttr(16)] public ETriggerType _triggerType; // TYPE_ENUM, etype: TriggerType, subtype: TYPE_UINT8
        [FieldAttr(17)] public u8 _triggerManifoldTolerance; // TYPE_UINT8, (Inlined from type: hkUFloat8)
        [FieldAttr(18)] public Half _dynamicFriction; // TYPE_HALF
        [FieldAttr(20)] public Half _staticFriction; // TYPE_HALF
        [FieldAttr(22)] public Half _restitution; // TYPE_HALF
        [FieldAttr(24)] public ECombinePolicy _frictionCombinePolicy; // TYPE_ENUM, etype: CombinePolicy, subtype: TYPE_UINT8
        [FieldAttr(25)] public ECombinePolicy _restitutionCombinePolicy; // TYPE_ENUM, etype: CombinePolicy, subtype: TYPE_UINT8
        [FieldAttr(26)] public Half _weldingTolerance; // TYPE_HALF
        [FieldAttr(28)] public float _maxContactImpulse; // TYPE_REAL
        [FieldAttr(32)] public float _fractionOfClippedImpulseToApply; // TYPE_REAL
        [FieldAttr(36)] public EMassChangerCategory _massChangerCategory; // TYPE_ENUM, etype: MassChangerCategory, subtype: TYPE_UINT8
        [FieldAttr(38)] public Half _massChangerHeavyObjectFactor; // TYPE_HALF
        [FieldAttr(40)] public Half _softContactForceFactor; // TYPE_HALF
        [FieldAttr(42)] public Half _softContactDampFactor; // TYPE_HALF
        [FieldAttr(44)] public u8 _softContactSeperationVelocity; // TYPE_UINT8, (Inlined from type: hkUFloat8)
        [FieldAttr(48)] public hknpSurfaceVelocity _surfaceVelocity; // TYPE_POINTER, ctype: hknpSurfaceVelocity, subtype: TYPE_STRUCT
        [FieldAttr(56)] public Half _disablingCollisionsBetweenCvxCvxDynamicObjectsDistance; // TYPE_HALF
        [FieldAttr(64)] public u64 _userData; // TYPE_UINT64
        [FieldAttr(72)] public bool _isShared; // TYPE_BOOL
    }
}