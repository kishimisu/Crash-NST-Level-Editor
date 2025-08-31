namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CPlayerRespawnStartMessage))]
    public class CPlayerRespawnStartMessage : CEntityMessage
    {
        [FieldAttr(56)] public igHandleMetaField _playerActor = new();
        [FieldAttr(64)] public CPlayerRespawnComponent.ERespawnType _respawnType = CPlayerRespawnComponent.ERespawnType.eRT_Unknown;
    }
}
