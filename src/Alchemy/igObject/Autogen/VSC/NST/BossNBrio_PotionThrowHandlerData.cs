namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class BossNBrio_PotionThrowHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _LeftThrowProjectileData = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _RightThrowProjectileData = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _LeftThrowPlayerDistanceInfluenceMinimum;
        [FieldAttr(nst: 60, ctr: 52)] public float _PotionThrowFarStartingRange;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _LeftThrowProjectileSpawnData = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _RightThrowProjectileSpawnData = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _LeftThrowFarProjectileSpawnData = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _RightThrowFarProjectileSpawnData = new();
    }
}
