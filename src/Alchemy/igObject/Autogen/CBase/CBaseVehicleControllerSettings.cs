namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CBaseVehicleControllerSettings : igObject
    {
        [FieldAttr(16)] public CTopSpeedVehicleSettingList? _topSpeedStat;
        [FieldAttr(24)] public CAccelerationVehicleSettingList? _accelerationStat;
        [FieldAttr(32)] public CManeuverVehicleSettingList? _maneuverStat;
        [FieldAttr(40)] public CArmorVehicleSettingList? _armorStat;
        [FieldAttr(48)] public CArenaDriftVehicleSettingList? _arenaDriftStat;
        [FieldAttr(56)] public CLinearDriftVehicleSettingList? _linearDriftStat;
        [FieldAttr(64)] public CDurabilityVehicleSettingList? _durabilityStat;
        [FieldAttr(72)] public CWeightVehicleSettingList? _weightStat;
        [FieldAttr(80)] public CInputVehicleSettings? _inputModifiersStat;
        [FieldAttr(88)] public igHandleMetaField _airStatsModifier = new();
        [FieldAttr(96)] public igHandleMetaField _secondarySurfaceStatsModifier = new();
        [FieldAttr(104)] public CVehicleStatsList? _activeStatsModifiers;
    }
}
