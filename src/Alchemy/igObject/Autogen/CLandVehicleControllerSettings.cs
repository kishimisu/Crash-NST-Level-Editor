namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class CLandVehicleControllerSettings : CBaseVehicleControllerSettings
    {
        [FieldAttr(112)] public CTractionVehicleSettingList? _tractionStat;
    }
}
