namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class BossNBrio_HulkPlatformManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _PlatformTemplate = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _PlatformSpawnHeightOffset;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _PlatformInitialWaypointList = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _PlatformWaypointList = new();
    }
}
