namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class CCEAtkRegion : CCombatNodeIntervalEvent
    {
        [FieldAttr(88)] public CAttackRegionShapeList? _regions;
        [FieldAttr(96)] public CCEAtkData? _attackData;
        [FieldAttr(104)] public bool _allowRepeatedAttacks;
        [FieldAttr(105)] public bool _detectProjectiles;
        [FieldAttr(112)] public CDamageData? _damage;
        [FieldAttr(120)] public bool _allowDamageWhenDead;
        [FieldAttr(124)] public int _maximumVictims = -1;
    }
}
