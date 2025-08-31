namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CWeightedSound : igObject
    {
        [FieldAttr(16)] public string? _sound = null;
        [FieldAttr(24)] public igHandleMetaField _soundHandle = new();
        [FieldAttr(32)] public int _weight = 1;
    }
}
