namespace Alchemy
{
    [ObjectAttr(208, 8)]
    public class CDamageData : igObject
    {
        public enum EDamageVibration : int
        {
            eDV_Auto = -2,
            eDV_None = -1,
            eDV_Weakest = 0,
            eDV_Weak = 1,
            eDV_Medium = 2,
            eDV_Strong = 3,
            eDV_Strongest = 4,
            eDV_WeakPain = 5,
            eDV_MediumPain = 6,
            eDV_StrongPain = 7,
        }

        [FieldAttr(16)] public CUpgradeableInt? _damageAmountUpgradeable;
        [FieldAttr(24)] public int _maxDamageAmount;
        [FieldAttr(28)] public uint _damageMods;
        [FieldAttr(32)] public EDamageType _damageType = EDamageType.eDMG_Basic;
        [FieldAttr(36)] public EAttackType _attackType;
        [FieldAttr(40)] public bool _allowFriendlyFire;
        [FieldAttr(44)] public float _repeatHitInterval = 3.0f;
        [FieldAttr(48)] public string? _immunityGroup = null;
        [FieldAttr(56)] public CTakeHitData? _takeHitData;
        [FieldAttr(64)] public float _freezeFrameDuration;
        [FieldAttr(68)] public EDamageVibration _vibration = CDamageData.EDamageVibration.eDV_Auto;
        [FieldAttr(72)] public CCombatNodeEvent? _selfCombatNodeEvent;
        [FieldAttr(80)] public CCombatNodeEvent? _victimCombatNodeEvent;
        [FieldAttr(88)] public CKnockawayFlightData? _knockawayFlightData;
        [FieldAttr(96)] public CKnockawayLandData? _knockawayLandData;
        [FieldAttr(104)] public float _knockawayImpulseMin;
        [FieldAttr(108)] public float _knockawayImpulseMax;
        [FieldAttr(112)] public float _knockawayAngleMin;
        [FieldAttr(116)] public float _knockawayAngleMax;
        [FieldAttr(120)] public CVehicleKnockawayData? _knockawayVehicles;
        [FieldAttr(128)] public CCombatSoundData? _soundData;
        [FieldAttr(136)] public igHandleMetaField _hitEffect = new();
        [FieldAttr(144)] public igHandleMetaField _hitFlashEffect = new();
        [FieldAttr(152)] public bool _ignoreGodMode;
        [FieldAttr(160)] public CEntityComponentDataList? _componentsToAttach;
        [FieldAttr(168)] public CEntityMessage.ENetworkSendRestriction _componentsToAttachReplication;
        [FieldAttr(176)] public CEntityMessage? _victimMessage;
        [FieldAttr(184)] public CEntityMessage? _attackerMessage;
        [FieldAttr(192)] public igNamedObject? _attackIdentifier;
        [FieldAttr(200)] public CUpgradeableFloat? _bonusCriticalHitChance;
    }
}
