namespace Alchemy
{
    [ObjectAttr(24, 8)]
    public class CSurfaceMotion : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _cachedSurfaceVelocity = new();
    }
}
