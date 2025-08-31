namespace Alchemy
{
    [ObjectAttr(152, 8)]
    public class CSoundSystemDataConfig : igObject
    {
        [FieldAttr(16)] public float _duckingMaxRateOfChange = 0.2f;
        [FieldAttr(20)] public float _duckingMaxChange = 0.4f;
        [FieldAttr(24)] public float _duckingIdealAsymptoticApproach = 0.666f;
        [FieldAttr(28)] public float _soundSpread = 70.0f;
        [FieldAttr(32)] public float _stereoSoundSpread = 180.0f;
        [FieldAttr(36)] public float _minSpatializationRadius = 60.0f;
        [FieldAttr(40)] public float _maxSpatializationRadius = 120.0f;
        [FieldAttr(44)] public float _ellipticalListenerInterpolationWideFactor = 2.0f;
        [FieldAttr(48)] public float _angularAttenuationInnerAngle = 22.5f;
        [FieldAttr(52)] public float _angularAttenuationOuterAngle = 90.0f;
        [FieldAttr(56)] public float _angularAttenuation = 1.0f;
        [FieldAttr(60)] public float _loudnessFactor = 1.0f;
        [FieldAttr(64)] public float _soundRangeShutoffScale = 1.5f;
        [FieldAttr(68)] public float _pauseFadeIn = 0.2f;
        [FieldAttr(72)] public float _dspOverrideFade = 2.0f;
        [FieldAttr(80)] public CAudioArchiveList? _permanentAudioBanks;
        [FieldAttr(88)] public int _channelCount = 128;
        [FieldAttr(92)] public int _defaultAudioArchiveCount = 32;
        [FieldAttr(96)] public int _specificAudioArchiveCount = 128;
        [FieldAttr(100)] public int _soundInstanceCount = 128;
        [FieldAttr(104)] public int _channelGroupCount = 128;
        [FieldAttr(108)] public int _soundGroupCount = 128;
        [FieldAttr(112)] public igAudioContext_StreamBufferUnits _streamBufferUnits = igAudioContext_StreamBufferUnits.kUnitsMs;
        [FieldAttr(116)] public float _streamBufferLengthSeconds = 2.0f;
        [FieldAttr(120)] public int _streamBufferLengthKilobytes = 146;
        [FieldAttr(124)] public int _streamDecodeBufferLength;
        [FieldAttr(128)] public float _minEdcSyncPitch = 0.97f;
        [FieldAttr(132)] public float _maxEdcSyncPitch = 1.02999997f;
        [FieldAttr(136)] public float _edcSyncSmoothTime = 2.0f;
        [FieldAttr(140)] public int _maxTotalStreamedSounds = 6;
        [FieldAttr(144)] public int _maxBufferingOrPlayingStreamedSounds = 3;
    }
}
