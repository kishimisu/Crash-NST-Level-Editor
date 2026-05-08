namespace Alchemy
{
    [ObjectAttr(nst: 144, ctr: 136, align: 4, metaType: typeof(CVscComponentData))]
    public class BlasterTech_CarrotReticle_ControlData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _CarrotBehaviorStates = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Unnamed_BoltPoint = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _CarrotMissileExplosionDamage = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _CarrotMissileImpactDamage = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _BunnyProjectileEntityData = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _DustBunnyTag = new();
        [FieldAttr(nst: 88, ctr: 80)] public float _CarrotMissileImpactRadius;
        [FieldAttr(nst: 92, ctr: 84)] public float _CarrotMissileExplosionRadius;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _BunnyProjectileSpawnData = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _BunnyProjectileTargetsQuery = new();
        [FieldAttr(nst: 112, ctr: 104)] public string? _StartControllingCarrotCustomEvent = null;
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _CarrotMissileVfx = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _ReticleVfx = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _CarrotExplosionVfx = new();
    }
}
