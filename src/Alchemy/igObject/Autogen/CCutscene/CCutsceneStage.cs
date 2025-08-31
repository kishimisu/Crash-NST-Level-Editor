namespace Alchemy
{
    [ObjectAttr(200, 8)]
    public class CCutsceneStage : igObject
    {
        public enum EStageState : int
        {
            eSS_Invalid = -1,
            eSS_Unprepared = 0,
            eSS_Preparing = 1,
            eSS_Waiting = 2,
            eSS_Playing = 3,
            eSS_PlayingMovie = 4,
            eSS_Finished = 5,
        }

        [FieldAttr(16)] public JuiceScene? _rootScene;
        [FieldAttr(24)] public CCutsceneActorList? _performers;
        [FieldAttr(32)] public igVec3fMetaField _origin = new();
        [FieldAttr(44)] public igVec3fMetaField _orientation = new();
        [FieldAttr(56)] public string? _name = null;
        [FieldAttr(64)] public float _secondsUntilPrepared;
        [FieldAttr(68)] public float _secondsInCutscene;
        [FieldAttr(72)] public float _startTime;
        [FieldAttr(76)] public float _endTime;
        [FieldAttr(80)] public EStageState _currentState;
        [FieldAttr(84)] public EStageState _nextState;
        [FieldAttr(88)] public bool _paused;
        [FieldAttr(89)] public bool _pausedAtEnd;
        [FieldAttr(92)] public float _seekingFrameRate = 10.0f;
        [FieldAttr(96)] public bool _isSeeking;
        [FieldAttr(104)] public CutsceneActionPlayCameraList? _cameras;
        [FieldAttr(112)] public igHandleMetaField _subtitlesProject = new();
        [FieldAttr(120)] public bool _isMovie;
        [FieldAttr(121)] public bool _shutdownOnFinish;
        [FieldAttr(124)] public int _movieFrameCount;
        [FieldAttr(128)] public igHandleMetaField _cutsceneEntity = new();
        [FieldAttr(136)] public CEntityMessage? _cutsceneEntityMessage;
        [FieldAttr(144)] public bool _pauseOnEnd;
        [FieldAttr(148)] public int _shotNumber;
        [FieldAttr(152)] public float _cameraTransitionInTime;
        [FieldAttr(156)] public float _cameraTransitionOutTime;
        [FieldAttr(160)] public COnCutsceneStagePreparedDelegate? _onCutsceneStagePrepared;
        [FieldAttr(168)] public COnCutsceneStagePreparedEventList? _onCutsceneStagePreparedList;
        [FieldAttr(176)] public COnCutsceneStageFinishedDelegate? _onCutsceneStageFinished;
        [FieldAttr(184)] public COnCutsceneStageFinishedEventList? _onCutsceneStageFinishedList;
        [FieldAttr(192)] public EGameStateKey _cutsceneStartedCountGameState = EGameStateKey.eGSK_None;
    }
}
