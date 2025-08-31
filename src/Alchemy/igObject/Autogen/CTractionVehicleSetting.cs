namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CTractionVehicleSetting : CBaseVehicleSetting
    {
        [FieldAttr(24)] public float _slowSurfaceSpeedEffect = 0.5f;
        [FieldAttr(28)] public float _slipperySurfaceTurnEffect = 0.5f;
    }
}
