namespace Alchemy
{
    // VSC object extracted from: common_Collectible_AkuAku_Spawned_c.igz

    [ObjectAttr(80, metaType: typeof(CVscComponentData))]
    public class common_Collectible_AkuAku_SpawnedData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _IsIlluminatedGameVar = new();
        [FieldAttr(48)] public igHandleMetaField _AkuAkuInvinciblityActive = new();
        [FieldAttr(56)] public igHandleMetaField _Count = new();
        [FieldAttr(64)] public igHandleMetaField _IdleVFX = new();
        [FieldAttr(72)] public igHandleMetaField _IlluminatedIdleVFX = new();
    }
}
