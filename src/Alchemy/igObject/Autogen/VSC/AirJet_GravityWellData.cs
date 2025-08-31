namespace Alchemy
{
    // VSC object extracted from: AirJet_GravityWell_c.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class AirJet_GravityWellData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Damage = new();
        [FieldAttr(48)] public igHandleMetaField _RicochetTag = new();
        [FieldAttr(56)] public float _AutoDetonationDelay;
        [FieldAttr(60)] public float _Lifetime;
        [FieldAttr(64)] public igHandleMetaField _InVortexQuery = new();
        [FieldAttr(72)] public igHandleMetaField _ExplosionSfx = new();
        [FieldAttr(80)] public igHandleMetaField _ProjectileLoop = new();
        [FieldAttr(88)] public igHandleMetaField _VortexArea = new();
    }
}
