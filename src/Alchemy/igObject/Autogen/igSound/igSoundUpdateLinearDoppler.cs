namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igSoundUpdateLinearDoppler : igSoundUpdateMethod
    {
        [FieldAttr(16)] public igListenerRelativeVelocityFrameReference? _frameReference;
        [FieldAttr(24)] public igPitchApplicator? _applicator;
        [FieldAttr(32)] public float _minRange;
        [FieldAttr(36)] public float _maxRange = 100.0f;
        [FieldAttr(40)] public float _valueAtMinRange;
        [FieldAttr(44)] public float _valueAtMaxRange;
    }
}
