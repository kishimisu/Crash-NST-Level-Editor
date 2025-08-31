namespace Alchemy
{
    [ObjectAttr(160, 8)]
    public class CDspSfxReverb : CDsp
    {
        [FieldAttr(48)] public float _dryLevel;
        [FieldAttr(52)] public float _room = -1.0f;
        [FieldAttr(56)] public float _roomHf;
        [FieldAttr(60)] public float _decayTime = 1.0f;
        [FieldAttr(64)] public float _decayHfRatio = 0.5f;
        [FieldAttr(68)] public float _reflections = -1.0f;
        [FieldAttr(72)] public float _reflectDelay = 0.02f;
        [FieldAttr(76)] public float _reverb;
        [FieldAttr(80)] public float _reverbDelay = 0.04f;
        [FieldAttr(84)] public float _diffusion = 100.0f;
        [FieldAttr(88)] public float _density = 100.0f;
        [FieldAttr(92)] public float _hfReference = 5000.0f;
        [FieldAttr(96)] public float _roomLf;
        [FieldAttr(100)] public float _lfReference = 250.0f;
        [FieldAttr(104)] public float _dryLevelValue;
        [FieldAttr(108)] public float _roomValue;
        [FieldAttr(112)] public float _roomHfValue;
        [FieldAttr(116)] public float _decayTimeValue;
        [FieldAttr(120)] public float _decayHfRatioValue;
        [FieldAttr(124)] public float _reflectionsValue;
        [FieldAttr(128)] public float _reflectDelayValue;
        [FieldAttr(132)] public float _reverbValue;
        [FieldAttr(136)] public float _reverbDelayValue;
        [FieldAttr(140)] public float _diffusionValue;
        [FieldAttr(144)] public float _densityValue;
        [FieldAttr(148)] public float _hfReferenceValue;
        [FieldAttr(152)] public float _roomLfValue;
        [FieldAttr(156)] public float _lfReferenceValue;
    }
}
