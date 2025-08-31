using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(160)]
    public class hkbTwistModifier : hkbModifier
    {
        public override uint Hash => 0x98d623bc;

        [FieldAttr(96)] public Vector4 _axisOfRotation; // TYPE_VECTOR4
        [FieldAttr(112)] public float _twistAngle; // TYPE_REAL
        [FieldAttr(116)] public i16 _startBoneIndex; // TYPE_INT16
        [FieldAttr(118)] public i16 _endBoneIndex; // TYPE_INT16
        [FieldAttr(120)] public ESetAngleMethod _setAngleMethod; // TYPE_ENUM, etype: SetAngleMethod, subtype: TYPE_INT8
        [FieldAttr(121)] public ERotationAxisCoordinates _rotationAxisCoordinates; // TYPE_ENUM, etype: RotationAxisCoordinates, subtype: TYPE_INT8
        [FieldAttr(122)] public bool _isAdditive; // TYPE_BOOL
        [FieldAttr(128)] public hkMemory<u32> _boneChainIndices; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
        [FieldAttr(144)] public hkMemory<u32> _parentBoneIndices; // TYPE_ARRAY, flags: SERIALIZE_IGNORED
    }
}