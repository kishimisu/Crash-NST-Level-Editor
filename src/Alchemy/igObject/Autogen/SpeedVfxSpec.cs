namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class SpeedVfxSpec : igObject
    {
        [FieldAttr(16)] public igRangedFloatMetaField _speedRange = new();
        [FieldAttr(24)] public int _vfxIntensityLevel = 1;
    }
}
