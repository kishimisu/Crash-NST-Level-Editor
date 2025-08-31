namespace Alchemy
{
    // VSC object extracted from: AirJet_Projectile_c.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class AirJet_ProjectileData : CVscComponentData
    {
        [FieldAttr(40)] public float _RicochetBonusLife;
        [FieldAttr(44)] public int _MaxBounces;
        [FieldAttr(48)] public igHandleMetaField _RicochetFilter = new();
        [FieldAttr(56)] public igHandleMetaField _LeftMuzzleVfx = new();
        [FieldAttr(64)] public igHandleMetaField _RightMuzzleVfx = new();
    }
}
