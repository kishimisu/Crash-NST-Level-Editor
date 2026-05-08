namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Collectible_AkuAku_SpawnedData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _IsIlluminatedGameVar = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _AkuAkuInvinciblityActive = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Count = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _IdleVFX = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _IlluminatedIdleVFX = new();
    }
}
