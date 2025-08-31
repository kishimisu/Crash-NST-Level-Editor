namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CAIAttackCoordinatorData : igObject
    {
        [FieldAttr(16)] public igRangedFloatMetaField _delayBetweenAttacks = new();
        [FieldAttr(24)] public int _maxActiveAttacks = 10;
        [FieldAttr(28)] public int _maxPendingAttacks = 100;
    }
}
