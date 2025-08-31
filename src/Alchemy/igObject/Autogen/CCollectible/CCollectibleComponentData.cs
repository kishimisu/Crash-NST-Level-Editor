namespace Alchemy
{
    [ObjectAttr(208, 8)]
    public class CCollectibleComponentData : igComponentData
    {
        [FieldAttr(24)] public ECollectibleType _collectibleType = ECollectibleType.eCT_Money;
        [FieldAttr(28)] public float _awardValue = 50.0f;
        [FieldAttr(32)] public float _alternateAwardValue = 1.0f;
        [FieldAttr(36)] public float _attractRadius = 125.0f;
        [FieldAttr(40)] public float _attractAcceleration = 2000.0f;
        [FieldAttr(44)] public bool _isShrinkable = true;
        [FieldAttr(48)] public float _attractSpeed = 350.0f;
        [FieldAttr(52)] public bool _killOnCollected = true;
        [FieldAttr(56)] public float _collectRadius = 10.0f;
        [FieldAttr(60)] public igRangedFloatMetaField _autoCollectDelay = new();
        [FieldAttr(68)] public bool _disableOnReturnToStartingHeight;
        [FieldAttr(72)] public float _sphereShapeRadius = 30.0f;
        [FieldAttr(80)] public igHandleMetaField _physicsMotion = new();
        [FieldAttr(88)] public igHandleMetaField _collisionMaterial = new();
        [FieldAttr(96)] public uint _collisionFlags = 400;
        [FieldAttr(104)] public igHandleMetaField _idleVfx = new();
        [FieldAttr(112)] public igHandleMetaField _trailVfx = new();
        [FieldAttr(120)] public igHandleMetaField _collectBeginVfx = new();
        [FieldAttr(128)] public igHandleMetaField _collectEndVfx = new();
        [FieldAttr(136)] public CBoltPoint? _vfxBoltPoint;
        [FieldAttr(144)] public bool _collectBeginVfxSpawnAtPosition;
        [FieldAttr(152)] public igHandleMetaField _spawnSfx = new();
        [FieldAttr(160)] public igHandleMetaField _pickupSfx = new();
        [FieldAttr(168)] public string? _heroPickupSfx = null;
        [FieldAttr(176)] public igHandleMetaField _collectedSfx = new();
        [FieldAttr(184)] public float _collectedRumbleAmount;
        [FieldAttr(188)] public float _collectedRumbleDuration;
        [FieldAttr(192)] public float _collectedVibrationAmount = 0.3f;
        [FieldAttr(196)] public float _collectedVibrationDuration = 0.2f;
        [FieldAttr(200)] public ECollectibleWorldModifierCategory _worldModifierCategory = ECollectibleWorldModifierCategory.eCWMC_UseCollectibleDefaults;
    }
}
