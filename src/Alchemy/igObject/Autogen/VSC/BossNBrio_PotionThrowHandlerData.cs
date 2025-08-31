namespace Alchemy
{
    // VSC object extracted from: BossNBrio_PotionThrowHandler_c.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class BossNBrio_PotionThrowHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _LeftThrowProjectileData = new();
        [FieldAttr(48)] public igHandleMetaField _RightThrowProjectileData = new();
        [FieldAttr(56)] public float _LeftThrowPlayerDistanceInfluenceMinimum;
        [FieldAttr(60)] public float _PotionThrowFarStartingRange;
        [FieldAttr(64)] public igHandleMetaField _LeftThrowProjectileSpawnData = new();
        [FieldAttr(72)] public igHandleMetaField _RightThrowProjectileSpawnData = new();
        [FieldAttr(80)] public igHandleMetaField _LeftThrowFarProjectileSpawnData = new();
        [FieldAttr(88)] public igHandleMetaField _RightThrowFarProjectileSpawnData = new();
    }
}
