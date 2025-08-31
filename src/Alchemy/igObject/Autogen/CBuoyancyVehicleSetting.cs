namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CBuoyancyVehicleSetting : CBaseVehicleSetting
    {
        [FieldAttr(24)] public CVehicleStats? _submergedStatsModifier;
    }
}
