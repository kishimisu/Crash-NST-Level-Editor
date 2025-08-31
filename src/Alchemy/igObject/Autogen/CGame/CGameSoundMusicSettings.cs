namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class CGameSoundMusicSettings : igObject
    {
        [FieldAttr(16)] public bool _audition;
        [FieldAttr(24)] public igHandleMetaField _nextStream = new();
        [FieldAttr(32)] public CWeightedSoundList? _variableNextStream;
        [FieldAttr(40)] public igHandleMetaField _stinger1 = new();
        [FieldAttr(48)] public igHandleMetaField _stinger2 = new();
        [FieldAttr(56)] public bool _flipStreams;
        [FieldAttr(60)] public float _fadeTime = 1.0f;
        [FieldAttr(64)] public EInterleavedMusicState _interleavedState = EInterleavedMusicState.eIMS_Traversal;
        [FieldAttr(68)] public ECombatMusicIntensity _combatMusicIntensity;
        [FieldAttr(72)] public igHandleMetaField _mix = new();
        [FieldAttr(80)] public bool _waitForOppositeStreamStopped;
        [FieldAttr(81)] public bool _disableTraversalMovementMix;
        [FieldAttr(84)] public float _newStinger1SyncTimeInSeconds;
        [FieldAttr(88)] public float _newStinger2SyncTimeInSeconds;
        [FieldAttr(92)] public float _nextMusicBeatsPerMinute = 100.0f;
        [FieldAttr(96)] public int _nextMusicBeatsPerMeasure = 4;
        [FieldAttr(100)] public int _syncToMusicMaxBeatsToWait = 4;
        [FieldAttr(104)] public bool _syncToTempo;
        [FieldAttr(112)] public CGameSoundMusicEventPatternList? _eventList;
        [FieldAttr(120)] public uint _priority = 4294967295;
    }
}
