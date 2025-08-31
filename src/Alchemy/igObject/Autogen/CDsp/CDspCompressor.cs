namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CDspCompressor : CDsp
    {
        [FieldAttr(48)] public float _threshold;
        [FieldAttr(52)] public float _attack = 50.0f;
        [FieldAttr(56)] public float _release = 50.0f;
        [FieldAttr(60)] public float _makeUpGain;
        [FieldAttr(64)] public float _thresholdValue;
        [FieldAttr(68)] public float _attackValue;
        [FieldAttr(72)] public float _releaseValue;
        [FieldAttr(76)] public float _makeUpGainValue;
    }
}
