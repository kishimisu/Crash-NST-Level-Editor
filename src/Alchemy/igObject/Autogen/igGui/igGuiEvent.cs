namespace Alchemy
{
    [ObjectAttr(24, 8)]
    public class igGuiEvent : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _sender = new();
    }
}
