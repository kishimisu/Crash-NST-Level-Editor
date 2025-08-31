namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CVehicleModeFilter : CBaseVehicleModeFilter
    {
        public enum EVehicleModeFilterType : uint
        {
            eVMFT_VehicleModeRequiredToBeActive = 0,
            eVMFT_VehicleModeRequiredToBeInactive = 1,
        }

        [FieldAttr(16)] public EVehicleModeFilterType _vehicleModeFilterType;
        [FieldAttr(20)] public CVehicleComponent.EVehicleMode _vehicleMode;
    }
}
