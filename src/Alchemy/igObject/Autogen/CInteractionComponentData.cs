namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CInteractionComponentData : CEntityComponentData
    {
        public enum EOnlineRestriction : uint
        {
            eOR_HostArbitrated = 0,
            eOR_LocalPlayerOnly = 1,
        }

        [FieldAttr(24)] public float _delayToReactivate = -1.0f;
        [FieldAttr(28)] public bool _disableAllInteraction;
        [FieldAttr(32)] public CInteractionData? _interactionData;
        [FieldAttr(40)] public bool _enabled = true;
        [FieldAttr(44)] public float _autoEnableDuration;
        [FieldAttr(48)] public EOnlineRestriction _onlineRestriction;
    }
}
