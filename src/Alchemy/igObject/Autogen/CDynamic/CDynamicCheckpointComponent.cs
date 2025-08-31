namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CDynamicCheckpointComponent : CEntityComponent
    {
        [FieldAttr(48)] public CCheckpoint? _dynamicCheckpoint;
        [FieldAttr(56)] public CPlayerStartEntity? _dynamicPlayerStart;
        [FieldAttr(64)] public igHandleMetaField _handleRespawnFunction = new();
    }
}
