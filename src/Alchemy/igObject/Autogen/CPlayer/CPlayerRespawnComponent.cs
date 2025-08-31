namespace Alchemy
{
    [ObjectAttr(248, 8)]
    public class CPlayerRespawnComponent : CEntityComponent
    {
        public enum ERespawnType : uint
        {
            eRT_RespawnTrigger = 0,
            eRT_InstantRespawnTrigger = 1,
            eRT_WaterRespawnTrigger = 2,
            eRT_IceRespawnTrigger = 3,
            eRT_CheckpointRespawn = 4,
            eRT_KillZ = 5,
            eRT_Instant = 6,
            eRT_PVPDeathDelayed = 7,
            eRT_Unknown = 8,
        }

        public enum EPointSelectionMethod : uint
        {
            ePSM_DifficultyBased = 0,
            ePSM_Closest = 1,
        }

        public enum ERespawnState : uint
        {
            eRS_None = 0,
            eRS_Delay = 1,
            eRS_WaitForSafe = 2,
            eRS_Searching = 3,
            eRS_TransitionIn = 4,
            eRS_TransitionOut = 5,
            eRS_WaitToFinish = 6,
        }

        [FieldAttr(48)] public CPlayerRespawnPointFinder? _finder;
        [FieldAttr(56)] public ERespawnState _respawnState;
        [FieldAttr(60)] public EPointSelectionMethod _pointSelectionMethod;
        [FieldAttr(64)] public igHandleMetaField _previousRespawnPoint = new();
        [FieldAttr(72)] public int _respawnAtSamePointCount;
        [FieldAttr(80)] public CTimer? _respawnTimer;
        [FieldAttr(88)] public bool _tetherDisabled;
        [FieldAttr(89)] public bool _targetable = true;
        [FieldAttr(90)] public bool _behaviorDisabled;
        [FieldAttr(92)] public ERespawnType _respawnType;
        [FieldAttr(96)] public CPlayerStartEntityHandleList? _respawnPoints;
        [FieldAttr(104)] public igHandleMetaField _chosenSpawnPoint = new();
        [FieldAttr(112)] public float _respawnDelayTime;
        [FieldAttr(120)] public igHandleMetaField _transitionInPlayerEffect = new();
        [FieldAttr(128)] public float _transitionInTimeSecs;
        [FieldAttr(136)] public igHandleMetaField _transitionOutPlayerEffect = new();
        [FieldAttr(144)] public float _transitionOutTimeSecs;
        [FieldAttr(148)] public bool _respawnOnGround = true;
        [FieldAttr(152)] public igVec3fMetaField _triggerPosition = new();
        [FieldAttr(164)] public float _timeRespawnButtonHeld;
        [FieldAttr(168)] public float _waitToFinishTime;
        [FieldAttr(172)] public float _waitToShowTime;
        [FieldAttr(176)] public igVec3fMetaField _cameraPosition = new();
        [FieldAttr(192)] public CCameraBase? _transitionOutCamera;
        [FieldAttr(200)] public CCameraBase? _transitionInCamera;
        [FieldAttr(208)] public bool _transitionFadeToBlack;
        [FieldAttr(212)] public float _transitionFadeFromBlackTime;
        [FieldAttr(216)] public float _fadeHoldTime;
        [FieldAttr(224)] public string? _transitionOutBehaviorState = null;
        [FieldAttr(232)] public CChangeRequestList? _changeRequests;
        [FieldAttr(240)] public bool _failedToRespawnAtOtherPlayer;
        [FieldAttr(241)] public bool _cameraTargetDisabled;
        [FieldAttr(242)] public bool _netIsInSafeState;
    }
}
