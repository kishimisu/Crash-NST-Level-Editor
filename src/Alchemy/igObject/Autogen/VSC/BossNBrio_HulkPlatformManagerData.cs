namespace Alchemy
{
    // VSC object extracted from: BossNBrio_HulkPlatformManager_c.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class BossNBrio_HulkPlatformManagerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _PlatformTemplate = new();
        [FieldAttr(48)] public float _PlatformSpawnHeightOffset;
        [FieldAttr(56)] public igHandleMetaField _PlatformInitialWaypointList = new();
        [FieldAttr(64)] public igHandleMetaField _PlatformWaypointList = new();
    }
}
