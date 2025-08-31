using Alchemy;

namespace Havok
{
    [ObjectAttr(40)]
    public class hkbFootIkGains : hkObject
    {
        public override uint Hash => 0xded7c527;

        [FieldAttr(0)] public float _onOffGain; // TYPE_REAL
        [FieldAttr(4)] public float _groundAscendingGain; // TYPE_REAL
        [FieldAttr(8)] public float _groundDescendingGain; // TYPE_REAL
        [FieldAttr(12)] public float _footPlantedGain; // TYPE_REAL
        [FieldAttr(16)] public float _footRaisedGain; // TYPE_REAL
        [FieldAttr(20)] public float _footLockingGain; // TYPE_REAL
        [FieldAttr(24)] public float _worldFromModelFeedbackGain; // TYPE_REAL
        [FieldAttr(28)] public float _errorUpDownBias; // TYPE_REAL
        [FieldAttr(32)] public float _alignWorldFromModelGain; // TYPE_REAL
        [FieldAttr(36)] public float _hipOrientationGain; // TYPE_REAL
    }
}