using Alchemy;

namespace Havok
{
    [ObjectAttr(72)]
    public class hkbFootIkDriverInfo : hkReferencedObject
    {
        public override uint Hash => 0x4bc775e1;

        [FieldAttr(16)] public hkMemory<hkbFootIkDriverInfoLeg> _legs; // TYPE_ARRAY, ctype: hkbFootIkDriverInfoLeg, subtype: TYPE_STRUCT
        [FieldAttr(32)] public float _raycastDistanceUp; // TYPE_REAL
        [FieldAttr(36)] public float _raycastDistanceDown; // TYPE_REAL
        [FieldAttr(40)] public float _originalGroundHeightMS; // TYPE_REAL
        [FieldAttr(44)] public float _verticalOffset; // TYPE_REAL
        [FieldAttr(48)] public u32 _collisionFilterInfo; // TYPE_UINT32
        [FieldAttr(52)] public float _forwardAlignFraction; // TYPE_REAL
        [FieldAttr(56)] public float _sidewaysAlignFraction; // TYPE_REAL
        [FieldAttr(60)] public float _sidewaysSampleWidth; // TYPE_REAL
        [FieldAttr(64)] public bool _lockFeetWhenPlanted; // TYPE_BOOL
        [FieldAttr(65)] public bool _useCharacterUpVector; // TYPE_BOOL
        [FieldAttr(66)] public bool _isQuadrupedNarrow; // TYPE_BOOL
        [FieldAttr(67)] public bool _keepSourceFootEndAboveGround; // TYPE_BOOL
    }
}