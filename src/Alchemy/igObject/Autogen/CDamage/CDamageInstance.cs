namespace Alchemy
{
    [ObjectAttr(192, 8)]
    public class CDamageInstance : igObject
    {
        [FieldAttr(16)] public CDamageData? _data;
        [FieldAttr(24)] public bool _dataIsPersistent = true;
        [FieldAttr(32)] public igHandleMetaField _attacker = new();
        [FieldAttr(40)] public igHandleMetaField _victim = new();
        [FieldAttr(48)] public igHandleMetaField _defender = new();
        [FieldAttr(56)] public igHandleMetaField _source = new();
        [FieldAttr(64)] public bool _succeeded = true;
        [FieldAttr(65)] public bool _missed;
        [FieldAttr(68)] public int _damageAmount = 1;
        [FieldAttr(72)] public uint _damageMods;
        [FieldAttr(76)] public bool _allowFriendlyFire;
        [FieldAttr(80)] public int _attackNumber;
        [FieldAttr(84)] public igVec3fMetaField _hitLocation = new();
        [FieldAttr(96)] public igVec3fMetaField _hitDirection = new();
        [FieldAttr(108)] public bool _spawnHitFx = true;
        [FieldAttr(112)] public igVec3fMetaField _collisionNormal = new();
        [FieldAttr(128)] public igHandleMetaField _material = new();
        [FieldAttr(136)] public igNamedObject? _attackIdentifier;
        [FieldAttr(144)] public float _knockawayImpulseMin;
        [FieldAttr(148)] public float _knockawayImpulseMax;
        [FieldAttr(152)] public float _knockawayAngleMin;
        [FieldAttr(156)] public float _knockawayAngleMax;
        [FieldAttr(160)] public float _bonusCriticalHitChance;
        [FieldAttr(168)] public CTakeHitData? _takeHitData;
        [FieldAttr(176)] public float _freezeFrameDuration;
        [FieldAttr(180)] public CDamageData.EDamageVibration _vibration = CDamageData.EDamageVibration.eDV_Auto;
        [FieldAttr(184)] public bool _ignoreImmunity;
        [FieldAttr(185)] public bool _isRedirected;
        [FieldAttr(186)] public bool _showVfxOnDeath = true;
    }
}
