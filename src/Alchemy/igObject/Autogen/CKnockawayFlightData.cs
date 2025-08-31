namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CKnockawayFlightData : igObject
    {
        [FieldAttr(16)] public float _transitionAltitude;
        [FieldAttr(20)] public float _recoveryAltitude;
        [FieldAttr(24)] public float _timeFactorAtTakeOff = 1.0f;
        [FieldAttr(28)] public float _timeFactorAtSummit = 1.0f;
        [FieldAttr(32)] public float _transitionToSummitDuration;
    }
}
