namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVehicleRiderComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CVehicleRiderData? _driverData;
        [FieldAttr(32)] public CVehicleRiderData? _passengerData;
    }
}
