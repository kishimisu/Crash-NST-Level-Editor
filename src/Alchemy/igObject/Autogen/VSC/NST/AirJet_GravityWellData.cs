namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class AirJet_GravityWellData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Damage = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _RicochetTag = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _AutoDetonationDelay;
        [FieldAttr(nst: 60, ctr: 52)] public float _Lifetime;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _InVortexQuery = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _ExplosionSfx = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _ProjectileLoop = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _VortexArea = new();
    }
}
