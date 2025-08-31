namespace Alchemy
{
    [ObjectAttr(216, 8)]
    public class CSoundInstance : igObject
    {
        [FieldAttr(16)] public igRawRefMetaField _channel = new();
        [FieldAttr(24)] public igHandleMetaField _entity = new();
        [FieldAttr(32)] public igHandleMetaField _sound = new();
        [FieldAttr(40)] public igHandleMetaField _nextSound = new();
        [FieldAttr(48)] public igHandleMetaField _subSound = new();
        [FieldAttr(56)] public float _defaultFrequency;
        [FieldAttr(60)] public float _rawPcmVolume;
        [FieldAttr(64)] public igTimeMetaField _firstTryPlayTime = new();
        [FieldAttr(68)] public igTimeMetaField _soundBufferStartTime = new();
        [FieldAttr(72)] public float _soundBufferDuration;
        [FieldAttr(76)] public igTimeMetaField _startEdcTime = new();
        [FieldAttr(80)] public igRawRefMetaField _dsp = new();
        [FieldAttr(88)] public float _dspCallbackOutput;
        [FieldAttr(92)] public float _distanceToFocus;
        [FieldAttr(96)] public igVec3fMetaField _position = new();
        [FieldAttr(108)] public igVec3fMetaField _forward = new();
        [FieldAttr(120)] public bool _loading;
        [FieldAttr(121)] public bool _paused;
        [FieldAttr(122)] public bool _positionUpdatedExternally;
        [FieldAttr(123)] public bool _hasBeenUnpaused;
        [FieldAttr(124)] public bool _isDelayed;
        [FieldAttr(128)] public uint _length;
        [FieldAttr(132)] public float _initialVolume = 1.0f;
        [FieldAttr(136)] public float _fadeVolume = 1.0f;
        [FieldAttr(140)] public float _duckingVolume = 1.0f;
        [FieldAttr(144)] public float _attenuation3dVolume = 1.0f;
        [FieldAttr(148)] public float _initialRandomness;
        [FieldAttr(152)] public float _basePitch = 1.0f;
        [FieldAttr(160)] public igHandleMetaField _dspOverrideSet = new();
        [FieldAttr(168)] public igPitchOverrideList? _pitchOverrides;
        [FieldAttr(176)] public CSoundInstanceHandleList? _additionalSoundInstances;
        [FieldAttr(184)] public igVscDelegateMetaField _stopDelegate = new();
        [FieldAttr(200)] public COnSoundInstanceStopEventList? _onStopEventList;
        [FieldAttr(208)] public igSoundUpdateMethodList? _dynamicUpdateData;
    }
}
