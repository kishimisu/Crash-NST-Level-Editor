namespace Alchemy
{
    [ObjectAttr(160, 8)]
    public class CActorInputListener : CInputListener
    {
        [FieldAttr(136)] public igHandleMetaField _actor = new();
        [FieldAttr(144)] public CEntityVscDelegateMetaField _activatorDataOut = new();
    }
}
