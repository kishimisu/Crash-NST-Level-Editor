namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CDspParamEq : CDsp
    {
        [FieldAttr(48)] public float _centerFreq = 8000.0f;
        [FieldAttr(52)] public float _octaveRange = 1.0f;
        [FieldAttr(56)] public float _frequencyGain = 1.0f;
        [FieldAttr(60)] public float _centerFreqValue;
        [FieldAttr(64)] public float _octaveRangeValue;
        [FieldAttr(68)] public float _frequencyGainValue;
    }
}
