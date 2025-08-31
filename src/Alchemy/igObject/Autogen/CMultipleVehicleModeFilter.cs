namespace Alchemy
{
    [ObjectAttr(24, 8)]
    public class CMultipleVehicleModeFilter : CBaseVehicleModeFilter
    {
        [FieldAttr(16)] public CVehicleModeFilterList? _vehicleModeFilters;
    }
}
