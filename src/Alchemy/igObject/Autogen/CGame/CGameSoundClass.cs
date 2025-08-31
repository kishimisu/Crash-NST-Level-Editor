namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CGameSoundClass : igObject
    {
        [FieldAttr(16)] public CGameSoundClassData? _data;
        [FieldAttr(24)] public float _cooldownTime;
        [FieldAttr(32)] public igHandleMetaField _playingSound = new();
        [FieldAttr(40)] public bool _lastPlaying;
        [FieldAttr(41)] public bool _initialFade;
        [FieldAttr(42)] public bool _fadeOut;
        [FieldAttr(48)] public CQueuedGameSoundList? _queuedSoundList;
        [FieldAttr(56)] public CQueuedGameSoundList? _queuedSoundToRemoveList;
        [FieldAttr(64)] public int _failedPlaybacks;
        [FieldAttr(68)] public int _interruptedCount;
        [FieldAttr(72)] public int _timedOutQueuedSounds;
        [FieldAttr(76)] public int _currentQueuedSounds;
        [FieldAttr(80)] public int _maxQueuedSounds;
        [FieldAttr(84)] public igTimeMetaField _lastFailedTime = new();
        [FieldAttr(88)] public igTimeMetaField _lastInterruptTime = new();
    }
}
