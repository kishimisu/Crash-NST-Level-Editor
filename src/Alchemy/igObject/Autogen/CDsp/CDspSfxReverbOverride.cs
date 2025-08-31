namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CDspSfxReverbOverride : CDspOverride
    {
        [FieldAttr(32)] public float _dryLevel;
        [FieldAttr(36)] public float _room = -1.0f;
        [FieldAttr(40)] public float _roomHf;
        [FieldAttr(44)] public float _decayTime = 1.0f;
        [FieldAttr(48)] public float _decayHfRatio = 0.5f;
        [FieldAttr(52)] public float _reflections = -1.0f;
        [FieldAttr(56)] public float _reflectDelay = 0.02f;
        [FieldAttr(60)] public float _reverb;
        [FieldAttr(64)] public float _reverbDelay = 0.04f;
        [FieldAttr(68)] public float _diffusion = 100.0f;
        [FieldAttr(72)] public float _density = 100.0f;
        [FieldAttr(76)] public float _hfReference = 5000.0f;
        [FieldAttr(80)] public float _roomLf;
        [FieldAttr(84)] public float _lfReference = 250.0f;
    }
}
