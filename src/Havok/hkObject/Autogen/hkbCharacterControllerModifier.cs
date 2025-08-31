using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(176)]
    public class hkbCharacterControllerModifier : hkbModifier
    {
        public override uint Hash => 0x74239623;

        [FieldAttr(88)] public hkbCharacterControllerModifierControlData _controlData; // TYPE_STRUCT, ctype: hkbCharacterControllerModifierControlData
        [FieldAttr(112)] public Vector4 _initialVelocity; // TYPE_VECTOR4
        [FieldAttr(128)] public EInitialVelocityCoordinates _initialVelocityCoordinates; // TYPE_ENUM, etype: InitialVelocityCoordinates, subtype: TYPE_INT8
        [FieldAttr(129)] public EMotionMode _motionMode; // TYPE_ENUM, etype: MotionMode, subtype: TYPE_INT8
        [FieldAttr(130)] public bool _forceDownwardMomentum; // TYPE_BOOL
        [FieldAttr(131)] public bool _applyGravity; // TYPE_BOOL
        [FieldAttr(132)] public bool _setInitialVelocity; // TYPE_BOOL
        [FieldAttr(133)] public bool _isTouchingGround; // TYPE_BOOL
        [FieldAttr(144)] public Vector4 _gravity; // TYPE_VECTOR4, flags: SERIALIZE_IGNORED
        [FieldAttr(160)] public bool _isInitialVelocityAdded; // TYPE_BOOL, flags: SERIALIZE_IGNORED
    }
}