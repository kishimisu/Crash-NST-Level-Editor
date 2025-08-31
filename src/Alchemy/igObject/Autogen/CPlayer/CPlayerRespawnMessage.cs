namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CPlayerRespawnMessage))]
    public class CPlayerRespawnMessage : CEntityMessage
    {
        [FieldAttr(56)] public igHandleMetaField _playerActor = new();
        [FieldAttr(64)] public CPlayerRespawnComponent.ERespawnType _respawnType = CPlayerRespawnComponent.ERespawnType.eRT_Unknown;
    }
}
