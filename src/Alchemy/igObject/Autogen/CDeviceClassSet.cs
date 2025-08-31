namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CDeviceClassSet : igObject
    {
        [FieldAttr(16)] public uint _deviceClasses = 31;
        [FieldAttr(20)] public bool _nintendoLayer;
    }
}
