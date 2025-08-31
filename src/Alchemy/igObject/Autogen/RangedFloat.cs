namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class RangedFloat : igObject
    {
        [FieldAttr(16)] public igRangedFloatMetaField _storage = new();
    }
}
