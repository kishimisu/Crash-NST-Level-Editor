namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 48, align: 8)]
    public class igSoundUpdateMethodVolumeByVelocity : igSoundUpdateMethod
    {
        [FieldAttr(nst: 16, ctr: 16)] public igVelocityFrameReference? _frameReference;
        [FieldAttr(nst: 24, ctr: 24)] public igVolumeApplicator? _applicator;
        [FieldAttr(nst: 32, ctr: 32)] public float _minRange;
        [FieldAttr(nst: 36, ctr: 36)] public float _maxRange = 100.0f;
        [FieldAttr(nst: 40, ctr: 40)] public float _valueAtMinRange;
        [FieldAttr(nst: 44, ctr: 44)] public float _valueAtMaxRange = 1.0f;
    }
}
