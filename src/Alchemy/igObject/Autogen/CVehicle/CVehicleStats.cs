namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class CVehicleStats : igObject
    {
        [FieldAttr(16)] public int _gripStat;
        [FieldAttr(20)] public int _buoyancyStat;
        [FieldAttr(24)] public int _hoverStat;
        [FieldAttr(28)] public int _driftStat;
        [FieldAttr(32)] public int _weightStat;
        [FieldAttr(36)] public int _accelerationStat;
        [FieldAttr(40)] public int _topSpeedStat;
        [FieldAttr(44)] public int _shieldStat;
        [FieldAttr(48)] public int _armorStat;
        [FieldAttr(52)] public int _maneuverStat;
        [FieldAttr(56)] public bool _dirty;
    }
}
