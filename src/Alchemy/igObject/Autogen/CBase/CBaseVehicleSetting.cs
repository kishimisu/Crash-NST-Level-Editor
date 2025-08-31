namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CBaseVehicleSetting : igObject
    {
        [FieldAttr(16)] public int _stat;
        [FieldAttr(20)] public bool _dirty;
    }
}
