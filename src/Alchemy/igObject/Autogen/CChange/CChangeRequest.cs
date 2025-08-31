namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CChangeRequest : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _manager = new();
        [FieldAttr(24)] public bool _requestEnabled;
        [FieldAttr(32)] public CScopedScheduledFunction? _scheduledChange;
    }
}
