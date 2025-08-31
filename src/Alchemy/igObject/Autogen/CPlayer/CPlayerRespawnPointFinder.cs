namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CPlayerRespawnPointFinder : igObject
    {
        public enum EState : uint
        {
            eS_None = 0,
            eS_InProgress = 1,
            eS_Success = 2,
            eS_Failure = 3,
        }

        public enum ESearchState : uint
        {
            eSS_None = 0,
            eSS_GroundCheck = 1,
            eSS_BlockerCheck = 2,
        }

        [FieldAttr(16)] public EState _state;
        [FieldAttr(20)] public ESearchState _searchState;
        [FieldAttr(24)] public int _cursor;
        [FieldAttr(28)] public int _offset;
        [FieldAttr(32)] public igVec3fMetaField _resultPosition = new();
        [FieldAttr(44)] public bool _resultIsOnGround = true;
        [FieldAttr(48)] public CPlayerRespawnGroundChecker? _groundChecker;
        [FieldAttr(56)] public CPlayerRespawnBlockerChecker? _blockerChecker;
        [FieldAttr(64)] public igHandleMetaField _respawnActor = new();
        [FieldAttr(72)] public bool _isVehicle;
        [FieldAttr(73)] public bool _isLandVehicle;
        [FieldAttr(74)] public bool _needsGroundCheck;
        [FieldAttr(76)] public EigBlockingType _blockingType;
        [FieldAttr(80)] public bool _forceMultiplayerLogic;
        [FieldAttr(84)] public igVec3fMetaField _positionAtRespawnRequest = new();
    }
}
