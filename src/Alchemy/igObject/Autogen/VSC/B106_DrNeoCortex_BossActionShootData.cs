namespace Alchemy
{
    // VSC object extracted from: B106_DrNeoCortex_BossActionShoot_c.igz

    [ObjectAttr(120, metaType: typeof(CVscComponentData))]
    public class B106_DrNeoCortex_BossActionShootData : CVscComponentData
    {
        public enum EReloadAction
        {
            NoReload = 0,
            Reload = 1,
            ReloadLong = 2,
        }

        public enum EProjectileType
        {
            Purple = 0,
            Green = 1,
            Blue = 2,
        }

        [FieldAttr(40)] public bool _IsReturnProjectileSuperStage;
        [FieldAttr(48)] public igHandleMetaField _ProjectileData = new();
        [FieldAttr(56)] public igHandleMetaField _BlueHazardMoverTemplate = new();
        [FieldAttr(64)] public igHandleMetaField _TargetingEntity = new();
        [FieldAttr(72)] public igHandleMetaField _ReturnProjectileStageTemplate = new();
        [FieldAttr(80)] public igHandleMetaField _ReturnProjectileStageTarget = new();
        [FieldAttr(88)] public EReloadAction _ReloadAction;
        [FieldAttr(92)] public EProjectileType _ProjectileType;
        [FieldAttr(96)] public float _DelayActionStart;
        [FieldAttr(104)] public igHandleMetaField _ProjectileSpawnData = new();
        [FieldAttr(112)] public bool _Bool;
    }
}
