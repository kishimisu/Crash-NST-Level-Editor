namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CSoundHandleOrName : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _soundHandle = new();
        [FieldAttr(24)] public string? _soundName = null;
    }
}
