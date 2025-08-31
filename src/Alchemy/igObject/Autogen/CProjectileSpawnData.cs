namespace Alchemy
{
    [ObjectAttr(184, 8)]
    public class CProjectileSpawnData : igObject
    {
        public enum EAimingMethod : uint
        {
            eAM_NoAiming = 0,
            eAM_AimAtTarget = 1,
            eAM_AimAtAimedPosition = 2,
            eAM_AimAtTargetThenPosition = 3,
            eAM_LeadTarget = 4,
        }

        public enum ELobbedTargettingMode : uint
        {
            eLTM_SolveForSpeed = 0,
            eLTM_SolveForAngle = 1,
            eLTM_SolveForAngleMax = 2,
            eLTM_SolveForGravity = 3,
        }

        public enum ESpawnPositionMode : uint
        {
            eSPM_AbsoluteWorldSpace = 0,
            eSPM_WorldSpaceOffset = 1,
            eSPM_EntityLocalOffset = 2,
            eSPM_BoltLocalOffset = 3,
            eSPM_SpawnOrientationOffset = 4,
        }

        public enum ESpawnOrientationMode : uint
        {
            eSOM_RelativeToWorld = 0,
            eSOM_RelativeToEntity = 1,
            eSOM_RelativeToBolt = 2,
        }

        public enum EReplicationMode : uint
        {
            eRM_False = 0,
            eRM_True = 1,
            eRM_Default = 2,
            eRM_Entity = 3,
        }

        [ObjectAttr(4)]
        public class BitfieldStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public ECombatTargetSelect _combatTargetSelect = ECombatTargetSelect.eCTS_First;
            [FieldAttr(3, size: 3)] public ECombatTargetList _combatTargetList;
            [FieldAttr(6, size: 3)] public CProjectileSpawnData.EAimingMethod _aimingMethod = CProjectileSpawnData.EAimingMethod.eAM_NoAiming;
            [FieldAttr(9, size: 2)] public CProjectileSpawnData.ELobbedTargettingMode _lobbedTargettingMode;
            [FieldAttr(11, size: 1)] public bool _fakeAiming;
            [FieldAttr(12, size: 1)] public bool _aimAtGround;
            [FieldAttr(13, size: 3)] public CProjectileSpawnData.ESpawnPositionMode _positionRelativeMode = CProjectileSpawnData.ESpawnPositionMode.eSPM_AbsoluteWorldSpace;
            [FieldAttr(16, size: 2)] public CProjectileSpawnData.ESpawnOrientationMode _angleRelativeMode = CProjectileSpawnData.ESpawnOrientationMode.eSOM_RelativeToWorld;
            [FieldAttr(18, size: 1)] public bool _useAttackerScale = false;
            [FieldAttr(19, size: 1)] public bool _useAttackerSpeedOverride;
            [FieldAttr(20, size: 1)] public bool _adjustProjectileSpeedAndRange;
            [FieldAttr(21, size: 4)] public int _spawnCount = 0;
            [FieldAttr(25, size: 1)] public bool _spreadDamagesOnce = false;
            [FieldAttr(26, size: 1)] public bool _spreadForceAimed;
            [FieldAttr(27, size: 1)] public bool _spreadAroundTarget;
            [FieldAttr(28, size: 1)] public bool _spreadSingleSpawnEffect;
            [FieldAttr(29, size: 1)] public bool _useSpecialTeamForProjectile;
            [FieldAttr(30, size: 1)] public bool _spawnAsChildOfAttacker = false;
            [FieldAttr(31, size: 1)] public bool _boltSpawnEffect;
        }

        [ObjectAttr(4)]
        public class BitfieldStorage2 : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _aimYaw = true;
            [FieldAttr(1, size: 1)] public bool _aimPitch = false;
            [FieldAttr(2, size: 1)] public bool _useRootEntityForAttackerSpeedOverride;
            [FieldAttr(3, size: 1)] public bool _spawnWhenOffScreen = false;
            [FieldAttr(4, size: 3)] public CProjectileSpawnData.EReplicationMode _netReplicate = CProjectileSpawnData.EReplicationMode.eRM_False;
            [FieldAttr(7, size: 3)] public ENetworkSendPriority _netSendPriority = ENetworkSendPriority.eNSP_Low;
            [FieldAttr(10, size: 1)] public bool _netReliable;
            [FieldAttr(11, size: 1)] public bool _recalculateTargetingOnPeer;
        }

        [FieldAttr(16)] public BitfieldStorage _bitfieldStorage = new();
        [FieldAttr(20)] public BitfieldStorage2 _bitfieldStorage2 = new();
        [FieldAttr(24)] public CBoltPoint? _targetBoltPoint;
        [FieldAttr(32)] public igVec3fMetaField _fakeAimingOffset = new();
        [FieldAttr(44)] public igRangedFloatMetaField _randomAimOffsetRadius = new();
        [FieldAttr(52)] public igVec3fMetaField _additionalAimingAngleOffset = new();
        [FieldAttr(64)] public u8 _maxAimAngleFromSpawnYaw = 180;
        [FieldAttr(65)] public u8 _maxAimAngleFromSpawnPitch = 180;
        [FieldAttr(68)] public igVec3fMetaField _positionOffset = new();
        [FieldAttr(80)] public igVec3fMetaField _positionOffsetRandomRange = new();
        [FieldAttr(92)] public igVec3fMetaField _angleOffset = new();
        [FieldAttr(104)] public igVec3fMetaField _angleOffsetRandomRange = new();
        [FieldAttr(120)] public CBoltPoint? _boltPoint;
        [FieldAttr(128)] public CBoltPoint? _passengerBoltPoint;
        [FieldAttr(136)] public float _initialSpeedOverride = -1.0f;
        [FieldAttr(140)] public float _spreadAngle = 90.0f;
        [FieldAttr(144)] public float _spreadRandomYawRange;
        [FieldAttr(148)] public float _spreadRandomPitchRange;
        [FieldAttr(152)] public igRangedFloatMetaField _spreadTargetOffset = new();
        [FieldAttr(160)] public float _spreadTargetAngleOffset = 20.0f;
        [FieldAttr(164)] public float _spreadHorizontalRange;
        [FieldAttr(168)] public float _spreadDepthArcRange;
        [FieldAttr(176)] public igHandleMetaField _spawnEffect = new();
    }
}
