namespace Alchemy
{
    [ObjectAttr(56, 8, metaObject: true)]
    public class CEntityMessage : Object
    {
        public enum ENetworkSendRestriction : uint
        {
            eNSR_Local = 0,
            eNSR_FromAuthorityToAll = 1,
            eNSR_FromAuthorityToAllReliable = 2,
            eNSR_FromCreatorAuthorityToAll = 3,
            eNSR_FromHostToAll = 4,
            eNSR_FromHostToAllReliable = 5,
            eNSR_Broadcast = 6,
            eNSR_BroadcastReliable = 7,
        }

        [FieldAttr(32)] public igHandleMetaField _sender = new();
        [FieldAttr(40)] public ENetworkSendRestriction _networkSendRestriction;
        [FieldAttr(44)] public bool _networkJoinInProgress;
        [FieldAttr(48)] public string? _networkJoinInProgressGroup = "default";
    }
}
