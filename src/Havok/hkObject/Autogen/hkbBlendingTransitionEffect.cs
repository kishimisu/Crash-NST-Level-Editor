using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(320)]
    public class hkbBlendingTransitionEffect : hkbTransitionEffect
    {
        public override uint Hash => 0x14e54c5c;

        [FieldAttr(168)] public float _duration; // TYPE_REAL
        [FieldAttr(172)] public float _toGeneratorStartTimeFraction; // TYPE_REAL
        [FieldAttr(176)] public u16 _flags; // TYPE_FLAGS, etype: FlagBits, subtype: TYPE_UINT16
        [FieldAttr(178)] public EEndMode _endMode; // TYPE_ENUM, etype: EndMode, subtype: TYPE_INT8
        [FieldAttr(179)] public EBlendCurve _blendCurve; // TYPE_ENUM, etype: BlendCurve, subtype: TYPE_INT8
        [FieldAttr(180)] public i16 _alignmentBone; // TYPE_INT16
        [FieldAttr(192)] public Vector4 _fromPos; // TYPE_VECTOR4, flags: SERIALIZE_IGNORED
        [FieldAttr(208)] public Quaternion _fromRot; // TYPE_QUATERNION, flags: SERIALIZE_IGNORED
        [FieldAttr(224)] public Vector4 _toPos; // TYPE_VECTOR4, flags: SERIALIZE_IGNORED
        [FieldAttr(240)] public Quaternion _toRot; // TYPE_QUATERNION, flags: SERIALIZE_IGNORED
        [FieldAttr(256)] public Vector4 _lastPos; // TYPE_VECTOR4, flags: SERIALIZE_IGNORED
        [FieldAttr(272)] public Quaternion _lastRot; // TYPE_QUATERNION, flags: SERIALIZE_IGNORED
        [FieldAttr(288)] public hkMemory<u32> _characterPoseAtBeginningOfTransition; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(304)] public float _timeRemaining; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(308)] public float _timeInTransition; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(312)] public i8 _toGeneratorSelfTranstitionMode; // TYPE_ENUM, subtype: TYPE_INT8, flags: SERIALIZE_IGNORED
        [FieldAttr(313)] public bool _initializeCharacterPose; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(314)] public bool _alignThisFrame; // TYPE_BOOL, flags: SERIALIZE_IGNORED
        [FieldAttr(315)] public bool _alignmentFinished; // TYPE_BOOL, flags: SERIALIZE_IGNORED
    }
}