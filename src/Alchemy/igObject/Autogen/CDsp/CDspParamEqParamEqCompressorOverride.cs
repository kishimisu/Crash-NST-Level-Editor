namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CDspParamEqParamEqCompressorOverride : CDspOverride
    {
        [FieldAttr(32)] public float _centerFreq1 = 8000.0f;
        [FieldAttr(36)] public float _octaveRange1 = 1.0f;
        [FieldAttr(40)] public float _frequencyGain1 = 1.0f;
        [FieldAttr(44)] public float _centerFreq2 = 8000.0f;
        [FieldAttr(48)] public float _octaveRange2 = 1.0f;
        [FieldAttr(52)] public float _frequencyGain2 = 1.0f;
        [FieldAttr(56)] public float _threshold;
        [FieldAttr(60)] public float _attack = 50.0f;
        [FieldAttr(64)] public float _release = 50.0f;
        [FieldAttr(68)] public float _makeUpGain;
    }
}
