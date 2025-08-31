namespace Alchemy
{
    // VSC object extracted from: BlasterTech_CarrotReticle_Control_c.igz

    [ObjectAttr(144, metaType: typeof(CVscComponentData))]
    public class BlasterTech_CarrotReticle_ControlData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _CarrotBehaviorStates = new();
        [FieldAttr(48)] public igHandleMetaField _Unnamed_BoltPoint = new();
        [FieldAttr(56)] public igHandleMetaField _CarrotMissileExplosionDamage = new();
        [FieldAttr(64)] public igHandleMetaField _CarrotMissileImpactDamage = new();
        [FieldAttr(72)] public igHandleMetaField _BunnyProjectileEntityData = new();
        [FieldAttr(80)] public igHandleMetaField _DustBunnyTag = new();
        [FieldAttr(88)] public float _CarrotMissileImpactRadius;
        [FieldAttr(92)] public float _CarrotMissileExplosionRadius;
        [FieldAttr(96)] public igHandleMetaField _BunnyProjectileSpawnData = new();
        [FieldAttr(104)] public igHandleMetaField _BunnyProjectileTargetsQuery = new();
        [FieldAttr(112)] public string? _StartControllingCarrotCustomEvent = null;
        [FieldAttr(120)] public igHandleMetaField _CarrotMissileVfx = new();
        [FieldAttr(128)] public igHandleMetaField _ReticleVfx = new();
        [FieldAttr(136)] public igHandleMetaField _CarrotExplosionVfx = new();
    }
}
