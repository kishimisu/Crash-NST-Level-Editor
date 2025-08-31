using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(240)]
    public class hkbCharacterData : hkReferencedObject
    {
        public override uint Hash => 0xfec46c1f;

        [FieldAttr(16)] public hkbCharacterControllerSetup _characterControllerSetup; // TYPE_STRUCT, ctype: hkbCharacterControllerSetup
        [FieldAttr(64)] public Vector4 _modelUpMS; // TYPE_VECTOR4
        [FieldAttr(80)] public Vector4 _modelForwardMS; // TYPE_VECTOR4
        [FieldAttr(96)] public Vector4 _modelRightMS; // TYPE_VECTOR4
        [FieldAttr(112)] public hkMemory<hkbVariableInfo> _characterPropertyInfos; // TYPE_ARRAY, ctype: hkbVariableInfo, subtype: TYPE_STRUCT
        [FieldAttr(128)] public hkMemory<i32> _numBonesPerLod; // TYPE_ARRAY, subtype: TYPE_INT32
        [FieldAttr(144)] public hkbVariableValueSet _characterPropertyValues; // TYPE_POINTER, ctype: hkbVariableValueSet, subtype: TYPE_STRUCT
        [FieldAttr(152)] public hkbFootIkDriverInfo _footIkDriverInfo; // TYPE_POINTER, ctype: hkbFootIkDriverInfo, subtype: TYPE_STRUCT
        [FieldAttr(160)] public hkbHandIkDriverInfo _handIkDriverInfo; // TYPE_POINTER, ctype: hkbHandIkDriverInfo, subtype: TYPE_STRUCT
        [FieldAttr(168)] public hkReferencedObject _aiControlDriverInfo; // TYPE_POINTER, ctype: hkReferencedObject, subtype: TYPE_STRUCT
        [FieldAttr(176)] public hkbCharacterStringData _stringData; // TYPE_POINTER, ctype: hkbCharacterStringData, subtype: TYPE_STRUCT
        [FieldAttr(184)] public hkbMirroredSkeletonInfo _mirroredSkeletonInfo; // TYPE_POINTER, ctype: hkbMirroredSkeletonInfo, subtype: TYPE_STRUCT
        [FieldAttr(192)] public hkMemory<i16> _boneAttachmentBoneIndices; // TYPE_ARRAY, subtype: TYPE_INT16
        [FieldAttr(208)] public hkMemory<Matrix4x4> _boneAttachmentTransforms; // TYPE_ARRAY, subtype: TYPE_MATRIX4
        [FieldAttr(224)] public float _scale; // TYPE_REAL
        [FieldAttr(228)] public i16 _numHands; // TYPE_INT16, flags: SERIALIZE_IGNORED
        [FieldAttr(230)] public i16 _numFloatSlots; // TYPE_INT16, flags: SERIALIZE_IGNORED
    }
}