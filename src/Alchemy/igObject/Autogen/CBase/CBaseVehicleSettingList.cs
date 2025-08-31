namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CBaseVehicleSettingList : igObjectList<CBaseVehicleSetting>
    {
        [FieldAttr(40)] public EVehicleStat _statType;
    }
}
