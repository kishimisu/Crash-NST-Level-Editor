using Alchemy;

namespace Havok
{
    [ObjectAttr(16)]
    public class hkbCharacterControllerModifierControlData : hkObject
    {
        public override uint Hash => 0xc4e809af;

        [FieldAttr(0)] public float _verticalGain; // TYPE_REAL
        [FieldAttr(4)] public float _horizontalCatchUpGain; // TYPE_REAL
        [FieldAttr(8)] public float _maxVerticalSeparation; // TYPE_REAL
        [FieldAttr(12)] public float _maxHorizontalSeparation; // TYPE_REAL
    }
}