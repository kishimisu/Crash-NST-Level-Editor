namespace Alchemy
{
    // VSC object extracted from: BlasterTech_DustBunnyMain_c.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class BlasterTech_DustBunnyMainData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Unnamed_BoltPoint = new();
        [FieldAttr(48)] public igHandleMetaField _SlowDebuffComponentData = new();
        [FieldAttr(56)] public igHandleMetaField _DustBunnyEnterDamage = new();
        [FieldAttr(64)] public float _BunnyLifeTime;
        [FieldAttr(68)] public float _BunnyMaxLifeTime;
        [FieldAttr(72)] public igHandleMetaField _DeathVfx = new();
        [FieldAttr(80)] public igHandleMetaField _LoopVfx = new();
        [FieldAttr(88)] public igHandleMetaField _SuckedVfx = new();
        [FieldAttr(96)] public igHandleMetaField _SpawnSoundVfx = new();
    }
}
