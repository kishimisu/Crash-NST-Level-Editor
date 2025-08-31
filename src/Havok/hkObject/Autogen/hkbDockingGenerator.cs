using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(224)]
    public class hkbDockingGenerator : hkbGenerator
    {
        public override uint Hash => 0x7f8f8240;

        [FieldAttr(136)] public i16 _dockingBone; // TYPE_INT16
        [FieldAttr(144)] public Vector4 _translationOffset; // TYPE_VECTOR4
        [FieldAttr(160)] public Quaternion _rotationOffset; // TYPE_QUATERNION
        [FieldAttr(176)] public EBlendType _blendType; // TYPE_ENUM, etype: BlendType, subtype: TYPE_INT8
        [FieldAttr(178)] public u16 _flags; // TYPE_FLAGS, etype: DockingFlagBits, subtype: TYPE_UINT16
        [FieldAttr(184)] public hkbGenerator _child; // TYPE_POINTER, ctype: hkbGenerator, subtype: TYPE_STRUCT
        [FieldAttr(192)] public i32 _intervalStart; // TYPE_INT32
        [FieldAttr(196)] public i32 _intervalEnd; // TYPE_INT32
        [FieldAttr(200)] public float _localTime; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(204)] public float _previousLocalTime; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(208)] public float _intervalStartLocalTime; // TYPE_REAL, flags: SERIALIZE_IGNORED
        [FieldAttr(212)] public float _intervalEndLocalTime; // TYPE_REAL, flags: SERIALIZE_IGNORED
    }
}