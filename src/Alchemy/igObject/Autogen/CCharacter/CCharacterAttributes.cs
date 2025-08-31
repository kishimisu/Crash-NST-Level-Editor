namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CCharacterAttributes : igObject
    {
        [FieldAttr(16)] public float _maximumHealth;
        [FieldAttr(20)] public float _baseResistance = 100.0f;
        [FieldAttr(24)] public float _meleeResistance;
        [FieldAttr(28)] public float _rangedResistance;
        [FieldAttr(32)] public float _baseStrength = 100.0f;
        [FieldAttr(36)] public float _meleeStrength;
        [FieldAttr(40)] public float _rangedStrength;
        [FieldAttr(44)] public float _speed;
        [FieldAttr(48)] public float _speedCrash2 = 130.0f;
        [FieldAttr(52)] public float _speedCrash3 = 130.0f;
        [FieldAttr(56)] public float _movementSpeed = 100.0f;
        [FieldAttr(60)] public float _attackSpeed = 100.0f;
        [FieldAttr(64)] public float _criticalHitChance;
        [FieldAttr(68)] public float _criticalHitMultiplier;
        [FieldAttr(72)] public CCharacterAttributeMultiplierList? _multipliers;
    }
}
