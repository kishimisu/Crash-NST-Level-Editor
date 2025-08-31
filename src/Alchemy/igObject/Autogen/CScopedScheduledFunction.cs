namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CScopedScheduledFunction : igObject
    {
        [FieldAttr(16)] public igRawRefMetaField _scheduledCallback = new();
        [FieldAttr(24)] public igHandleMetaField _callbackOwner = new();
        [FieldAttr(32)] public igObject? _userData;
        [FieldAttr(40)] public igHandleMetaField _handle = new();
    }
}
