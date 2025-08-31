namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CInputVehicleSettings : igObject
    {
        public enum EInputModificationType : uint
        {
            eIMT_None = 0,
            eIMT_ForceReleased = 1,
            eIMT_ForcePressed = 2,
        }

        [FieldAttr(16)] public EInputModificationType _vehicleAcceleration;
        [FieldAttr(20)] public EInputModificationType _vehicleBraking;
        [FieldAttr(24)] public EInputModificationType _vehicleDrifting;
    }
}
