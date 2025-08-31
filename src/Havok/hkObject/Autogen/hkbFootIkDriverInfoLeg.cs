using Alchemy;
using System.Numerics;

namespace Havok
{
    [ObjectAttr(80)]
    public class hkbFootIkDriverInfoLeg : hkObject
    {
        public override uint Hash => 0xfcb4eea5;

        [FieldAttr(0)] public Vector4 _kneeAxisLS; // TYPE_VECTOR4
        [FieldAttr(16)] public Vector4 _footEndLS; // TYPE_VECTOR4
        [FieldAttr(32)] public float _footPlantedAnkleHeightMS; // TYPE_REAL
        [FieldAttr(36)] public float _footRaisedAnkleHeightMS; // TYPE_REAL
        [FieldAttr(40)] public float _maxAnkleHeightMS; // TYPE_REAL
        [FieldAttr(44)] public float _minAnkleHeightMS; // TYPE_REAL
        [FieldAttr(48)] public float _maxKneeAngleDegrees; // TYPE_REAL
        [FieldAttr(52)] public float _minKneeAngleDegrees; // TYPE_REAL
        [FieldAttr(56)] public i16 _hipIndex; // TYPE_INT16
        [FieldAttr(58)] public i16 _hipSiblingIndex; // TYPE_INT16
        [FieldAttr(60)] public i16 _kneeIndex; // TYPE_INT16
        [FieldAttr(62)] public i16 _kneeSiblingIndex; // TYPE_INT16
        [FieldAttr(64)] public i16 _ankleIndex; // TYPE_INT16
        [FieldAttr(66)] public bool _ForceFootGround; // TYPE_BOOL
    }
}