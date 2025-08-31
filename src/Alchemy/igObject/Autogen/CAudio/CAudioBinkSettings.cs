namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CAudioBinkSettings : igObject
    {
        [FieldAttr(16)] public string? _binkName = null;
        [FieldAttr(24)] public float _volume = 1.0f;
    }
}
