namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class CCheckpoint : igNamedObject
    {
        [FieldAttr(24)] public igHandleMetaField _playerStart = new();
        [FieldAttr(32)] public int _chapterNumber;
        [FieldAttr(36)] public bool _showUI = true;
        [FieldAttr(37)] public bool _loadMapStart;
        [FieldAttr(40)] public igHandleMetaField _prerequisiteStoryQuest = new();
        [FieldAttr(48)] public CCheckpointEventList? _onCheckpointLoadStartedList;
        [FieldAttr(56)] public CCheckpointEventDelegate? _onCheckpointLoadStarted;
        [FieldAttr(64)] public CCheckpointEventList? _onCheckpointFadeOutFinishedList;
        [FieldAttr(72)] public CCheckpointEventDelegate? _onCheckpointFadeOutFinished;
        [FieldAttr(80)] public CCheckpointEventList? _onCheckpointFadeInStartedList;
        [FieldAttr(88)] public CCheckpointEventDelegate? _onCheckpointFadeInStarted;
        [FieldAttr(96)] public CCheckpointEventList? _onCheckpointLoadedList;
        [FieldAttr(104)] public CCheckpointEventDelegate? _onCheckpointLoaded;
        [FieldAttr(112)] public CCheckpointEventList? _onCheckpointReachedList;
        [FieldAttr(120)] public CCheckpointEventDelegate? _onCheckpointReached;
    }
}
