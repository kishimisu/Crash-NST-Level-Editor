namespace Alchemy
{
    [ObjectAttr(120, 8)]
    public class CWaterVehicleControllerSettings : CBaseVehicleControllerSettings
    {
        [FieldAttr(112)] public CBuoyancyVehicleSettingList? _buoyancyStat;
    }
}
