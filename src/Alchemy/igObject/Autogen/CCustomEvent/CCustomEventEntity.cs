namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CCustomEventEntity))]
    public class CCustomEventEntity : CCustomEvent
    {
        [FieldAttr(64)] public igHandleMetaField _entity = new();
    }
}
