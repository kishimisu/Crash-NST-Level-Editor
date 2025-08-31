namespace Alchemy
{
    [ObjectAttr(152, 8, metaType: typeof(CButtonListenerHandler))]
    public class CButtonListenerHandler : CBehaviorLogic
    {
        public enum EButtonState : uint
        {
            eBS_Down = 0,
            eBS_Up = 1,
            eBS_Triggered = 2,
            eBS_Released = 3,
        }

        public enum ECooldownType : uint
        {
            eCType_TriggerOnStart = 0,
            eCType_TriggerOnEnd = 1,
        }

        [FieldAttr(80)] public EXBUTTON _button;
        [FieldAttr(84)] public EButtonState _buttonStateToFireEvent = CButtonListenerHandler.EButtonState.eBS_Triggered;
        [FieldAttr(88)] public string? _behaviorEvent = null;
        [FieldAttr(96)] public CEntityMessage.ENetworkSendRestriction _networkEventRestriction;
        [FieldAttr(100)] public bool _authorityOnly;
        [FieldAttr(104)] public CEntityMessage? _message;
        [FieldAttr(112)] public float _cooldownTime;
        [FieldAttr(120)] public string? _attackState = null;
        [FieldAttr(128)] public ECooldownType _cooldownType = CButtonListenerHandler.ECooldownType.eCType_TriggerOnEnd;
        [FieldAttr(132)] public bool _checkExtraButtons;
        [FieldAttr(136)] public EXBUTTON _extraButton1 = EXBUTTON.MAX;
        [FieldAttr(140)] public EXBUTTON _extraButton2 = EXBUTTON.MAX;
        [FieldAttr(144)] public CButtonListenerInstanceTable? _instances;
    }
}
