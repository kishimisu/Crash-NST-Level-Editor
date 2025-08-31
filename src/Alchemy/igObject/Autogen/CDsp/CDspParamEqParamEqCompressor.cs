namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class CDspParamEqParamEqCompressor : CDsp
    {
        [FieldAttr(48)] public float _centerFreq1 = 8000.0f;
        [FieldAttr(52)] public float _octaveRange1 = 1.0f;
        [FieldAttr(56)] public float _frequencyGain1 = 1.0f;
        [FieldAttr(60)] public float _centerFreq2 = 8000.0f;
        [FieldAttr(64)] public float _octaveRange2 = 1.0f;
        [FieldAttr(68)] public float _frequencyGain2 = 1.0f;
        [FieldAttr(72)] public float _threshold;
        [FieldAttr(76)] public float _attack = 50.0f;
        [FieldAttr(80)] public float _release = 50.0f;
        [FieldAttr(84)] public float _makeUpGain;
        [FieldAttr(88)] public float _centerFreq1Value;
        [FieldAttr(92)] public float _octaveRange1Value;
        [FieldAttr(96)] public float _frequencyGain1Value;
        [FieldAttr(100)] public float _centerFreq2Value;
        [FieldAttr(104)] public float _octaveRange2Value;
        [FieldAttr(108)] public float _frequencyGain2Value;
        [FieldAttr(112)] public float _thresholdValue;
        [FieldAttr(116)] public float _attackValue;
        [FieldAttr(120)] public float _releaseValue;
        [FieldAttr(124)] public float _makeUpGainValue;
    }
}
