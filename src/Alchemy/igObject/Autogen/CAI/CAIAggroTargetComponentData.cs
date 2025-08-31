namespace Alchemy
{
    [ObjectAttr(72, 4)]
    public class CAIAggroTargetComponentData : CEntityComponentData
    {
        public enum EAttackerArrangement : uint
        {
            eAT_Auto = 0,
            eAT_Circle = 1,
            eAT_Line = 2,
        }

        [FieldAttr(24)] public float _aggroPerDamageDone;
        [FieldAttr(28)] public float _maxDamageAggro = 600.0f;
        [FieldAttr(32)] public float _damageAggroDecayRate = 200.0f;
        [FieldAttr(36)] public float _damageAggroMaxDistance = 500.0f;
        [FieldAttr(40)] public float _damageAggroMultiplierMinDistance = 300.0f;
        [FieldAttr(44)] public float _damageAggroMultiplierAtMinDistance = 1.0f;
        [FieldAttr(48)] public float _damageAggroMultiplierAtMaxDistance;
        [FieldAttr(52)] public float _minDurationBetweenAttacks;
        [FieldAttr(56)] public int _maxSimultaneousAttacks = -1;
        [FieldAttr(60)] public int _maxMeleeAttackers = -1;
        [FieldAttr(64)] public EAttackerArrangement _attackerArrangement;
    }
}
