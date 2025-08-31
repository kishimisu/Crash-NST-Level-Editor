namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igGuiActionPlaySound : igGuiAction
    {
        [FieldAttr(48)] public igHandleMetaField _sound = new();
    }
}
