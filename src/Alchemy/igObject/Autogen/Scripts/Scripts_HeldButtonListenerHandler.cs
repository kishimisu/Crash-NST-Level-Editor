namespace Alchemy
{
    [ObjectAttr(200, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_HeldButtonListenerHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public EXBUTTON Button;
        [FieldAttr(84)] public EXBUTTON SecondaryButton;
        [FieldAttr(88)] public bool MustTriggerButton;
        [FieldAttr(89)] public bool ThresholdOnce;
        [FieldAttr(96)] public igHandleMetaField InfiniteDurationSkillUpgrade = new();
        [FieldAttr(104)] public float MaxHeldTime;
        [FieldAttr(108)] public float HeldThresholdTime;
        [FieldAttr(112)] public float MinimumHeldTime;
        [FieldAttr(120)] public string? StartBehaviorEvent = null;
        [FieldAttr(128)] public string? EndBehaviorEvent = null;
        [FieldAttr(136)] public string? ThresholdBehaviorEvent = null;
        [FieldAttr(144)] public string? ThresholdEndBehaviorEvent = null;
        [FieldAttr(152)] public CEntityMessage.ENetworkSendRestriction NetworkEventRestriction;
        [FieldAttr(156)] public bool AuthorityOnly;
        [FieldAttr(160)] public CEntityMessage? StartMessage;
        [FieldAttr(168)] public CEntityMessage? EndMessage;
        [FieldAttr(176)] public CEntityMessage? ThresholdMessage;
        [FieldAttr(184)] public CEntityMessage? ThresholdEndMessage;
        [FieldAttr(192)] public Dictionary_2? _instances;
    }
}
