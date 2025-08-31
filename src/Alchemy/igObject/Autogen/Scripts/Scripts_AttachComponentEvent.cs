namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CDotNetCombatNodeEvent))]
    public class Scripts_AttachComponentEvent : CDotNetCombatNodeEvent
    {
        [FieldAttr(32)] public ECombatTargetSelect CombatTargets;
        [FieldAttr(40)] public CEntityComponentData? _componentToAttach;
        [FieldAttr(48)] public CEntityMessage? _entityMessage;
        [FieldAttr(56)] public bool _sendMessageToSponsor;
        [FieldAttr(60)] public CEntityMessage.ENetworkSendRestriction _networkComponentAttachment;
    }
}
