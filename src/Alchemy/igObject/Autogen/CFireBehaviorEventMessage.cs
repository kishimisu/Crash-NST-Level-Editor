namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CFireBehaviorEventMessage))]
    public class CFireBehaviorEventMessage : CEntityMessage
    {
        [FieldAttr(56)] public string? _eventName = null;
    }
}
