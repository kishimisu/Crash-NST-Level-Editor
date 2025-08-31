namespace Alchemy
{
    [ObjectAttr(224, 8)]
    public class CSound : igObject
    {
        [ObjectAttr(4)]
        public class SoundFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _shouldLoad = true;
            [FieldAttr(1, size: 1)] public bool _looping;
            [FieldAttr(2, size: 3)] public ESoundPauseType _pauseType;
            [FieldAttr(5, size: 2)] public EPlayBehavior _playBehavior;
            [FieldAttr(7, size: 2)] public EPlayFeature _playFeature = EPlayFeature.ePF_RANDOM;
            [FieldAttr(9, size: 1)] public bool _useDuckingGainDirectly;
            [FieldAttr(10, size: 1)] public bool _duckingInverted;
            [FieldAttr(11, size: 1)] public bool _canBeDucked = false;
            [FieldAttr(12, size: 2)] public ESound3dBehavior _threeDBehavior = ESound3dBehavior.eS3B_2d;
        }

        [ObjectAttr(4)]
        public class RuntimeSoundFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _streaming;
            [FieldAttr(1, size: 1)] public bool _playingAdditionalSounds;
            [FieldAttr(2, size: 1)] public bool _initialized;
            [FieldAttr(3, size: 1)] public bool _isStreamed;
            [FieldAttr(4, size: 1)] public bool _mute;
            [FieldAttr(5, size: 1)] public bool _solo;
        }

        [FieldAttr(16)] public SoundFlags _soundFlags = new();
        [FieldAttr(20)] public RuntimeSoundFlags _runtimeSoundFlags = new();
        [FieldAttr(24)] public CSoundInstanceHandleList? _currentlyPlayingSounds;
        [FieldAttr(32)] public igTimeMetaField _lastPlayTime = new();
        [FieldAttr(40)] public igIntList? _orderToPlayList;
        [FieldAttr(48)] public string? _name = "NOT_SET";
        [FieldAttr(56)] public float _startTime;
        [FieldAttr(60)] public u8 _playPercentage = 100;
        [FieldAttr(61)] public u8 _maxPlaybacks = 2;
        [FieldAttr(62)] public u8 _priority = 100;
        [FieldAttr(63)] public u8 _pitch = 127;
        [FieldAttr(64)] public u8 _pitchRandomnessRange = 100;
        [FieldAttr(65)] public u8 _duckingGroup = 5;
        [FieldAttr(68)] public float _delay;
        [FieldAttr(72)] public string? _soundGroupName = "Default_Normal";
        [FieldAttr(80)] public igHandleMetaField _dspOverrideSet = new();
        [FieldAttr(88)] public igSoundUpdateMethodList? _dynamicUpdateData;
        [FieldAttr(96)] public CSubSoundList? _subSoundList;
        [FieldAttr(104)] public float _volume = 0.5f;
        [FieldAttr(108)] public float _volumeRandomnessRange;
        [FieldAttr(112)] public float _fadeIn;
        [FieldAttr(116)] public float _fadeOut = 0.3f;
        [FieldAttr(120)] public string? _channelGroupName = null;
        [FieldAttr(128)] public float _duckingAmount;
        [FieldAttr(132)] public float _cooldown;
        [FieldAttr(136)] public CSoundAttenuateOnUse? _attenuateOnUse;
        [FieldAttr(144)] public float _min3d = 300.0f;
        [FieldAttr(148)] public float _max3d = 1500.0f;
        [FieldAttr(152)] public float _coneInsideAngle = 360.0f;
        [FieldAttr(156)] public float _coneOutsideAngle = 360.0f;
        [FieldAttr(160)] public float _coneOutsideLevel = 1.0f;
        [FieldAttr(164)] public float _delayRandomnessRange;
        [FieldAttr(168)] public CSpeakerVolumes? _speakerVolumes;
        [FieldAttr(176)] public CSoundHandleOrNameList? _additionalSoundsToPlay;
        [FieldAttr(184)] public igHandleMetaField _nextSound = new();
        [FieldAttr(192)] public bool _edcSynced;
        [FieldAttr(193)] public bool _movieSynced;
        [FieldAttr(194)] public bool _trackPCMVolume;
        [FieldAttr(200)] public igHandleMetaField _channelGroup = new();
        [FieldAttr(208)] public igHandleMetaField _soundGroup = new();
        [FieldAttr(216, false)] public CAudioArchive? _ownerAudioArchive;
    }
}
