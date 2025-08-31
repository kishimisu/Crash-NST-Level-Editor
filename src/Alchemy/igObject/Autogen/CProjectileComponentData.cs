namespace Alchemy
{
    [ObjectAttr(552, 8)]
    public class CProjectileComponentData : CEntityComponentData
    {
        public enum EProjectileInitialPositionCollisionCheck : uint
        {
            ePIPCC_Auto = 0,
            ePIPCC_On = 1,
            ePIPCC_Off = 2,
        }

        [ObjectAttr(4)]
        public class BitfieldStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _capInitialSpeed;
            [FieldAttr(1, size: 1)] public bool _orientToMovement = false;
            [FieldAttr(2, size: 1)] public bool _movementDelayUntilMessage;
            [FieldAttr(3, size: 1)] public bool _accelerateToFullSpeed;
            [FieldAttr(4, size: 1)] public bool _dieOnContact = false;
            [FieldAttr(5, size: 1)] public bool _dieOnDamage = false;
            [FieldAttr(6, size: 1)] public bool _onlyDamageTarget;
            [FieldAttr(7, size: 1)] public bool _damageOtherProjectiles;
            [FieldAttr(8, size: 1)] public bool _ignoreDieOnDamageForDestructibles;
            [FieldAttr(9, size: 1)] public bool _explodeOnDeath;
            [FieldAttr(10, size: 1)] public bool _followGroundDebugDraw;
            [FieldAttr(11, size: 1)] public bool _killWhenExceedingSlope;
            [FieldAttr(12, size: 1)] public bool _snapToFollowGroundDistance;
            [FieldAttr(13, size: 1)] public bool _stickAllowDamage;
            [FieldAttr(14, size: 1)] public bool _bounceOnContact;
            [FieldAttr(15, size: 1)] public bool _dieOnBounceComplete = false;
            [FieldAttr(16, size: 1)] public bool _alignDeathEffectsToLastBounce;
            [FieldAttr(17, size: 1)] public bool _boltSpawnEffect = false;
            [FieldAttr(18, size: 1)] public bool _deathEffectAligned = false;
            [FieldAttr(19, size: 1)] public bool _explodeEffectAligned = false;
            [FieldAttr(20, size: 1)] public bool _bounceEffectAligned = false;
            [FieldAttr(21, size: 1)] public bool _stickEffectAligned = false;
            [FieldAttr(22, size: 1)] public bool _killEffectOnStick;
            [FieldAttr(23, size: 1)] public bool _reticleEffectRemoveOnContact;
            [FieldAttr(24, size: 1)] public bool _stopSpawnSoundOnDeath;
            [FieldAttr(25, size: 1)] public bool _stopLoopSoundOnStick;
            [FieldAttr(26, size: 1)] public bool _sendDeathMessageToSelf;
            [FieldAttr(27, size: 1)] public bool _sendDeathMessageToParent;
            [FieldAttr(28, size: 1)] public bool _sendBounceCompleteMessageToSelf;
            [FieldAttr(29, size: 1)] public bool _sendBounceMessageOnEveryBounce;
            [FieldAttr(30, size: 1)] public bool _sendExceedingSlopeMessage;
            [FieldAttr(31, size: 1)] public bool _allowDeflection = false;
        }

        [ObjectAttr(4)]
        public class BitfieldStorage2 : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _removeWhenBehindCamera;
            [FieldAttr(1, size: 1)] public bool _needsOnContactEvents;
            [FieldAttr(2, size: 1)] public bool _useAttackerForForwardTraceFiltering;
            [FieldAttr(3, size: 2)] public CProjectileComponentData.EProjectileInitialPositionCollisionCheck _checkInitialPositionCollision;
            [FieldAttr(5, size: 1)] public bool _stopHomingWithNoEntityTarget = false;
            [FieldAttr(6, size: 1)] public bool _homingPlanarForwardMatchVehicleMaxSpeed = false;
            [FieldAttr(7, size: 1)] public bool _followWater;
        }

        [FieldAttr(24)] public BitfieldStorage _bitfieldStorage = new();
        [FieldAttr(28)] public BitfieldStorage2 _bitfieldStorage2 = new();
        [FieldAttr(32)] public CUpgradeableProjectileLifeTime? _lifetimeUpgradeable;
        [FieldAttr(40)] public CUpgradeableProjectileLifeTime? _lifetimeLinear;
        [FieldAttr(48)] public CUpgradeableProjectileLifeTime? _lifetimeArena;
        [FieldAttr(56)] public CUpgradeableProjectileLifeTime? _lifetimeExpedition;
        [FieldAttr(64)] public CUpgradeableProjectileMaxRange? _maxRangeUpgradeable;
        [FieldAttr(72)] public CUpgradeableProjectileMaxRange? _maxRangeLinear;
        [FieldAttr(80)] public CUpgradeableProjectileMaxRange? _maxRangeArena;
        [FieldAttr(88)] public CUpgradeableProjectileMaxRange? _maxRangeExpedition;
        [FieldAttr(96)] public EProjectileMovementMode _movementMode;
        [FieldAttr(104)] public CUpgradeableProjectileSpeed? _speedUpgradeable;
        [FieldAttr(112)] public CUpgradeableProjectileSpeed? _speedLinear;
        [FieldAttr(120)] public CUpgradeableProjectileSpeed? _speedArena;
        [FieldAttr(128)] public CUpgradeableProjectileSpeed? _speedExpedition;
        [FieldAttr(136)] public CUpgradeableProjectileSpeed? _speedAir;
        [FieldAttr(144)] public float _lobbedGravity = 1000.0f;
        [FieldAttr(148)] public float _movementDelay;
        [FieldAttr(152)] public float _initialSpeedWhenAccelerating;
        [FieldAttr(156)] public float _acceleration = 1000.0f;
        [FieldAttr(160)] public igVec3fMetaField _initialSpinAxis = new();
        [FieldAttr(172)] public float _initialSpinSpeed;
        [FieldAttr(176)] public float _collisionRadius = 5.0f;
        [FieldAttr(180)] public float _entityCollisionDelay;
        [FieldAttr(184)] public float _worldCollisionDelay;
        [FieldAttr(192)] public CDamageData? _damage;
        [FieldAttr(200)] public float _damageRadius = 50.0f;
        [FieldAttr(208)] public CTriggerVolumeComponentData? _damageTriggerVolume;
        [FieldAttr(216)] public float _damageAttackerDelay = -1.0f;
        [FieldAttr(224)] public CUpgradeableProjectileExplodeRadius? _explodeRadiusUpgradeable;
        [FieldAttr(232)] public CDamageData? _explodeDamage;
        [FieldAttr(240)] public float _homingTurnRate = 180.0f;
        [FieldAttr(244)] public float _homingTurnRateAcceleration;
        [FieldAttr(248)] public float _homingTurnRateMax = 5400.0f;
        [FieldAttr(252)] public CProjectileSpawnData.EAimingMethod _overrideAimingMethod;
        [FieldAttr(256)] public float _homingDelay;
        [FieldAttr(260)] public float _homingStopDistance;
        [FieldAttr(264)] public float _homingPlanarForwardStrength = 1.0f;
        [FieldAttr(268)] public float _homingPlanarForwardMaxSpeed = -1.0f;
        [FieldAttr(272)] public float _homingPlanarLateralStrength = 0.5f;
        [FieldAttr(276)] public float _homingPlanarLateralMaxSpeed = 500.0f;
        [FieldAttr(280)] public float _lobbedCorrectionImpulseStrength;
        [FieldAttr(284)] public float _desiredGroundDistance;
        [FieldAttr(288)] public float _maxGroundSlopeToFollow = 45.0f;
        [FieldAttr(292)] public float _groundTraceForwardDistance = 100.0f;
        [FieldAttr(296)] public igHandleMetaField _targetWaterSurfaceMaterial = new();
        [FieldAttr(304)] public uint _stickModes;
        [FieldAttr(308)] public float _stickDuration = 2.0f;
        [FieldAttr(312)] public CEntityMessage? _stickMessage;
        [FieldAttr(320)] public igHandleMetaField _stickBoltPoint = new();
        [FieldAttr(328)] public int _numBounces = 3;
        [FieldAttr(332)] public float _bounceRestitution = 1.0f;
        [FieldAttr(336)] public CUpgradeableVfx? _spawnEffectUpgradeable;
        [FieldAttr(344)] public CUpgradeableVfx? _loopEffectUpgradeable;
        [FieldAttr(352)] public igVfxManager.EffectKillType _loopEffectKillType;
        [FieldAttr(360)] public CUpgradeableVfx? _deathEffectUpgradeable;
        [FieldAttr(368)] public float _deathByTimeoutFadeDuration = 0.25f;
        [FieldAttr(376)] public CUpgradeableVfx? _explodeEffectUpgradeable;
        [FieldAttr(384)] public CUpgradeableVfx? _bounceEffectUpgradeable;
        [FieldAttr(392)] public CUpgradeableVfx? _stickEffectUpgradeable;
        [FieldAttr(400)] public CUpgradeableVfx? _bounceCompleteEffectUpgradeable;
        [FieldAttr(408)] public CUpgradeableVfx? _reticleEffect;
        [FieldAttr(416)] public igHandleMetaField _spawnSound = new();
        [FieldAttr(424)] public igHandleMetaField _loopSound = new();
        [FieldAttr(432)] public igHandleMetaField _deathSound = new();
        [FieldAttr(440)] public igHandleMetaField _explodeSound = new();
        [FieldAttr(448)] public igHandleMetaField _bounceSound = new();
        [FieldAttr(456)] public igHandleMetaField _stickSound = new();
        [FieldAttr(464)] public igHandleMetaField _bounceCompleteSound = new();
        [FieldAttr(472)] public int _poolSize = 5;
        [FieldAttr(480)] public CEntityMessage? _deathMessage;
        [FieldAttr(488)] public CEntityMessage? _bounceCompleteMessage;
        [FieldAttr(496)] public CTelegram? _unheldTelegram;
        [FieldAttr(504)] public CEntityMessage? _exceedingSlopeMessage;
        [FieldAttr(512)] public CUpgradeableModel? _model;
        [FieldAttr(520)] public u8 _collisionDirtyCounter;
        [FieldAttr(528)] public CPhysicsComponentData? _physicsData;
        [FieldAttr(536)] public CCollisionMaterial? _collisionMaterial;
        [FieldAttr(544)] public CPhysicsMotionProperties? _motionProperties;
    }
}
