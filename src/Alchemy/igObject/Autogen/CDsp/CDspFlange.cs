namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CDspFlange : CDsp
    {
        [FieldAttr(48)] public float _dryMix = 0.44999999f;
        [FieldAttr(52)] public float _wetMix = 0.55f;
        [FieldAttr(56)] public float _depth = 1.0f;
        [FieldAttr(60)] public float _rate = 0.1f;
        [FieldAttr(64)] public float _dryMixValue;
        [FieldAttr(68)] public float _wetMixValue;
        [FieldAttr(72)] public float _depthValue;
        [FieldAttr(76)] public float _rateValue;
    }
}
