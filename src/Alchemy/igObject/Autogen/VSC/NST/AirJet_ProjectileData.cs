namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class AirJet_ProjectileData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _RicochetBonusLife;
        [FieldAttr(nst: 44, ctr: 36)] public int _MaxBounces;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _RicochetFilter = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _LeftMuzzleVfx = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _RightMuzzleVfx = new();
    }
}
