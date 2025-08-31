namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CLocalizedLine : igObject
    {
        [FieldAttr(16)] public string? _string = null;
        [FieldAttr(24)] public igHandleMetaField _sound = new();
    }
}
