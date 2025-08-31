namespace Alchemy
{
    // VSC object extracted from: BossNBrio_AiBossManager_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class BossNBrio_AiBossManagerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _BossHulkTemplate = new();
        [FieldAttr(48)] public igHandleMetaField _BossStageList = new();
        [FieldAttr(56)] public igHandleMetaField _Damage_Data = new();
    }
}
