namespace Alchemy
{
    [ObjectAttr(400, 8)]
    public class CZoneInfo : CChunkInfo
    {
        [ObjectAttr(4)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _isBoss;
            [FieldAttr(1, size: 1)] public bool _magicMomentIntro = false;
            [FieldAttr(2, size: 1)] public bool _isMenu;
            [FieldAttr(3, size: 1)] public bool _isFmv;
            [FieldAttr(4, size: 1)] public bool _isSecret;
            [FieldAttr(5, size: 1)] public bool _smokeTestAllMaps = false;
            [FieldAttr(6, size: 1)] public bool _smokeTestAllMapsCafe = false;
            [FieldAttr(7, size: 1)] public bool _alwaysUseHugoVoiceOvers;
        }

        [FieldAttr(32)] public string? _debugMenuName = null;
        [FieldAttr(40)] public ELevelStreamingType _levelStreamingType;
        [FieldAttr(44)] public int _manualChunkCount = 2;
        [FieldAttr(48)] public igSizeTypeMetaField _levelPoolSize = new();
        [FieldAttr(56)] public igSizeTypeMetaField _globalChunkPoolSize = new();
        [FieldAttr(64)] public float _platinumTime = 120.0f;
        [FieldAttr(68)] public float _goldTime = 180.0f;
        [FieldAttr(72)] public float _sapphireTime = 240.0f;
        [FieldAttr(80)] public string? _loadMovieName = null;
        [FieldAttr(88)] public string? _loadScreenName = null;
        [FieldAttr(96)] public string? _menuToOpenOnLoad = null;
        [FieldAttr(104)] public string? _saveName = null;
        [FieldAttr(112)] public string? _build = "normal";
        [FieldAttr(120)] public EGameYear _year = EGameYear.eGY_Count;
        [FieldAttr(124)] public EZoneCategory _category = EZoneCategory.eZC_Count;
        [FieldAttr(128)] public string? _displayName = null;
        [FieldAttr(136)] public string? _hint = "";
        [FieldAttr(144)] public string? _bossName = null;
        [FieldAttr(152)] public string? _storyModePresenceText = null;
        [FieldAttr(160)] public Flags _flags = new();
        [FieldAttr(164)] public float _cameraNearPlane = 32.0f;
        [FieldAttr(168)] public float _cameraClipPlane = 2.0f;
        [FieldAttr(172)] public float _smokeTestTimeLimit = 2.0f;
        [FieldAttr(176)] public float _screenOuterSafeAreaRight = 50.0f;
        [FieldAttr(180)] public float _screenOuterSafeAreaLeft = 50.0f;
        [FieldAttr(184)] public float _screenOuterSafeAreaTop = 50.0f;
        [FieldAttr(188)] public float _screenOuterSafeAreaBottom = 50.0f;
        [FieldAttr(192)] public float _screenOuterSafeAreaBottomCoop = 90.0f;
        [FieldAttr(196)] public int _targetLevel = 1;
        [FieldAttr(200)] public float _defaultCameraTargetRadiusOverride = -1.0f;
        [FieldAttr(204)] public EZoneInfoProgressionGroup _progressionGroup;
        [FieldAttr(208)] public igHandleMetaField _nextMap = new();
        [FieldAttr(216)] public igHandleMetaField _juiceDomain = new();
        [FieldAttr(224)] public CStatisticData? _highScoreLeaderboard;
        [FieldAttr(232)] public CStatisticData? _fastestRaceTimeLeaderboard;
        [FieldAttr(240)] public CStatisticData? _fastestOnlineRaceTimeLeaderboard;
        [FieldAttr(248)] public CStatisticData? _fastestLapTimeLeaderboard;
        [FieldAttr(256)] public CStatisticData? _fastestTimeTrialLeaderboard;
        [FieldAttr(264)] public CLevelGoalList? _levelObjectives;
        [FieldAttr(272)] public igHandleMetaField _landObjective = new();
        [FieldAttr(280)] public igHandleMetaField _seaObjective = new();
        [FieldAttr(288)] public igHandleMetaField _skyObjective = new();
        [FieldAttr(296)] public bool _endsOnAStar;
        [FieldAttr(304)] public CCheckpointList? _checkpoints;
        [FieldAttr(312)] public igHandleMetaField _associatedStoryQuest = new();
        [FieldAttr(320)] public EGameStateKey _levelStartedCountGameState = EGameStateKey.eGSK_None;
        [FieldAttr(324)] public EGameStateKey _levelCompletedCountGameState = EGameStateKey.eGSK_None;
        [FieldAttr(328)] public EGameStateKey _collectiblesRewardedBitMask = EGameStateKey.eGSK_None;
        [FieldAttr(332)] public float _expectedCompletionTime = 300.0f;
        [FieldAttr(336)] public CZoneInfoSave? _saveData;
        [FieldAttr(344)] public int _progressionIndex = -1;
        [FieldAttr(348)] public int _dynamicDifficultyIndex = -1;
        [FieldAttr(352)] public int _dynamicDifficultyTargetTime;
        [FieldAttr(356)] public float _aoBakeMinRayDistance = 0.1f;
        [FieldAttr(360)] public float _aoBakeMaxRayDistance = 1.0f;
        [FieldAttr(364)] public float _aoBakeRegularization = 0.1f;
        [FieldAttr(368)] public igHandleMetaField _saveSlotImage = new();
        [FieldAttr(376)] public bool _planarReflectionsEnabled;
        [FieldAttr(384)] public string? _overrideCharacter = null;
        [FieldAttr(392)] public string? _zoneVehicle = null;
    }
}
