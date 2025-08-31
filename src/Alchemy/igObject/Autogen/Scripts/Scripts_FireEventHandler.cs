namespace Alchemy
{
    [ObjectAttr(96, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_FireEventHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public string? _activateEvent = null;
        [FieldAttr(88)] public string? _deactivateEvent = null;
    }
}
