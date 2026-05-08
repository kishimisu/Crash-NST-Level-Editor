namespace Alchemy
{
    [ObjectAttr(nst: 120, ctr: 112, align: 4, metaType: typeof(CVscComponentData))]
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

        [FieldAttr(nst: 40, ctr: 32)] public bool _IsReturnProjectileSuperStage;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _ProjectileData = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _BlueHazardMoverTemplate = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _TargetingEntity = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _ReturnProjectileStageTemplate = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _ReturnProjectileStageTarget = new();
        [FieldAttr(nst: 88, ctr: 80)] public EReloadAction _ReloadAction;
        [FieldAttr(nst: 92, ctr: 84)] public EProjectileType _ProjectileType;
        [FieldAttr(nst: 96, ctr: 88)] public float _DelayActionStart;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _ProjectileSpawnData = new();
        [FieldAttr(nst: 112, ctr: 104)] public bool _Bool;
    }
}
