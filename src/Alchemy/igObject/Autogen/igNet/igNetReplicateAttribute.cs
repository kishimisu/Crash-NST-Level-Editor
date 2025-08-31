namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class igNetReplicateAttribute : igObject
    {
        [FieldAttr(16)] public string? _getter = null;
        [FieldAttr(24)] public string? _setter = null;
        [FieldAttr(32)] public float _precision;
        [FieldAttr(36)] public float _min;
        [FieldAttr(40)] public float _max;
        [FieldAttr(44)] public bool _interpolate;
        [FieldAttr(45)] public bool _extrapolate;
        [FieldAttr(46)] public bool _supersample;
        [FieldAttr(48)] public string? _predictor = null;
        [FieldAttr(56)] public float _maxExtrapolationTime = 1.0f;
        [FieldAttr(60)] public float _smoothing;
        [FieldAttr(64)] public float _maxSmoothingDistance;
        [FieldAttr(68)] public bool _dependency;
        [FieldAttr(69)] public bool _timeShift;
    }
}
