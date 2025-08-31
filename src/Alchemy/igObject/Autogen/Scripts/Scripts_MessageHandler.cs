namespace Alchemy
{
    [ObjectAttr(96, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_MessageHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public CEntityMessage? ActivationMessage;
        [FieldAttr(88)] public CEntityMessage? DeactivationMessage;
    }
}
