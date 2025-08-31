namespace Alchemy
{
    // VSC object extracted from: BlasterTech_Vacuum_Shot_c.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class BlasterTech_Vacuum_ShotData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _VacuumStates = new();
        [FieldAttr(48)] public igHandleMetaField _ChargeEffectBoltPoint = new();
        [FieldAttr(56)] public igHandleMetaField _ShotgunVfxBoltPoint = new();
        [FieldAttr(64)] public igHandleMetaField _DustBunnyTag = new();
        [FieldAttr(72)] public int _DamageMultiplier;
        [FieldAttr(80)] public igHandleMetaField _ChargeEffect = new();
        [FieldAttr(88)] public igHandleMetaField _ShotgunVfx = new();
    }
}
