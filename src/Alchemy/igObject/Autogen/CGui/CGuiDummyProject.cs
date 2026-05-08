namespace Alchemy
{
    [ObjectAttr(nst: 264, ctr: 264, align: 8)]
    public class CGuiDummyProject : igGuiProject
    {
        [FieldAttr(nst: 232, ctr: 232)] public igHandleMetaField _openedProject = new();
        [FieldAttr(nst: 240, ctr: 240)] public igVscDelegateMetaField _openedCallback = new();
        [FieldAttr(nst: 256, ctr: 256)] public igGuiEventList? _queuedEvents;
    }
}
