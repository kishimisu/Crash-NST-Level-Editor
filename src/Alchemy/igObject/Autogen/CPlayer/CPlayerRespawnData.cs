namespace Alchemy
{
    [ObjectAttr(328, 8)]
    public class CPlayerRespawnData : igObject
    {
        [FieldAttr(16)] public bool _respawnAtLastCheckpoint;
        [FieldAttr(20)] public float _historyUpdateDistance = 25.0f;
        [FieldAttr(24)] public int _historySkipOffsetActionPack = 4;
        [FieldAttr(28)] public float _groundCheckUpDistance = 150.0f;
        [FieldAttr(32)] public float _groundCheckDownDistance = 150.0f;
        [FieldAttr(36)] public float _vehicleGroundDownCheckDistanceMultiplier = 4.0f;
        [FieldAttr(40)] public float _vehicleGroundUpCheckDistanceMultiplier = 1.0f;
        [FieldAttr(44)] public float _blockerAcceptableGroundDifference = 30.0f;
        [FieldAttr(48)] public float _blockerCheckRadius = 60.0f;
        [FieldAttr(52)] public float _blockerCheckHeight = 250.0f;
        [FieldAttr(56)] public float _minRespawnDistanceSelf;
        [FieldAttr(60)] public float _maxRespawnDistanceSelf = 600.0f;
        [FieldAttr(64)] public float _minRespawnDistanceOtherPlayer = 150.0f;
        [FieldAttr(68)] public float _maxRespawnDistanceOtherPlayer = 600.0f;
        [FieldAttr(72)] public float _fallbackDropHeightSelf = 150.0f;
        [FieldAttr(76)] public float _fallbackDropHeightOtherPlayer = 150.0f;
        [FieldAttr(80)] public float _respawnCooldown = 3.0f;
        [FieldAttr(88)] public CDamageData? _respawnDamageData;
        [FieldAttr(96)] public CDifficultySpecificFloat? _difficultyRespawnDamage;
        [FieldAttr(104)] public CDifficultySpecificInt? _jumpRetryCount;
        [FieldAttr(112)] public float _respawnDelayTime = 0.5f;
        [FieldAttr(116)] public float _instantRespawnDelayTime = 0.1f;
        [FieldAttr(120)] public igHandleMetaField _transitionInPlayerEffect = new();
        [FieldAttr(128)] public float _transitionInTimeSecs = 0.5f;
        [FieldAttr(136)] public igHandleMetaField _transitionOutPlayerEffect = new();
        [FieldAttr(144)] public float _transitionOutTimeSecs = 0.5f;
        [FieldAttr(148)] public float _waterRespawnDelayTime = 0.5f;
        [FieldAttr(152)] public igHandleMetaField _waterTransitionInPlayerEffect = new();
        [FieldAttr(160)] public float _waterTransitionInTimeSecs = 0.5f;
        [FieldAttr(168)] public igHandleMetaField _waterTransitionOutPlayerEffect = new();
        [FieldAttr(176)] public float _waterTransitionOutTimeSecs = 0.5f;
        [FieldAttr(180)] public float _iceRespawnDelayTime = 0.5f;
        [FieldAttr(184)] public igHandleMetaField _iceTransitionInPlayerEffect = new();
        [FieldAttr(192)] public float _iceTransitionInTimeSecs = 0.5f;
        [FieldAttr(200)] public igHandleMetaField _iceTransitionOutPlayerEffect = new();
        [FieldAttr(208)] public float _iceTransitionOutTimeSecs = 0.5f;
        [FieldAttr(216)] public igHandleMetaField _iceMaterialOverrideOnPlayerEffect = new();
        [FieldAttr(224)] public float _iceRespawnFinishedMovementDelayTimeSecs = 1.0f;
        [FieldAttr(228)] public float _iceRespawnWaitToFinishShowDelayTimeSecs = 0.5f;
        [FieldAttr(232)] public float _pvpDeathRespawnDelayTime;
        [FieldAttr(240)] public igHandleMetaField _pvpDeathTransitionInPlayerEffect = new();
        [FieldAttr(248)] public float _pvpDeathTransitionInTimeSecs = 1.5f;
        [FieldAttr(256)] public igHandleMetaField _pvpDeathTransitionOutPlayerEffect = new();
        [FieldAttr(264)] public float _pvpDeathTransitionOutTimeSecs = 0.5f;
        [FieldAttr(268)] public float _checkpointRespawnDelayTime;
        [FieldAttr(272)] public igHandleMetaField _checkpointTransitionInPlayerEffect = new();
        [FieldAttr(280)] public float _checkpointTransitionInTimeSecs = 1.0f;
        [FieldAttr(288)] public igHandleMetaField _checkpointTransitionOutPlayerEffect = new();
        [FieldAttr(296)] public float _checkpointTransitionOutTimeSecs = 0.3f;
        [FieldAttr(300)] public bool _checkpointTransitionFadeToBlack = true;
        [FieldAttr(304)] public float _checkpointFadeHoldTime = 0.2f;
        [FieldAttr(308)] public float _transitionFadeFromBlackTime = 0.3f;
        [FieldAttr(312)] public string? _checkpointTransitionOutBehaviorState = "SpawnIn";
        [FieldAttr(320)] public float _checkpointRespawnWaitToFinishShowDelayTimeSecs = -1.0f;
        [FieldAttr(324)] public float _cameraTargetBlendOutTime = 0.25f;
    }
}
