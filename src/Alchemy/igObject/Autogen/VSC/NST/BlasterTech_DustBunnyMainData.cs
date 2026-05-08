namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class BlasterTech_DustBunnyMainData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Unnamed_BoltPoint = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _SlowDebuffComponentData = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _DustBunnyEnterDamage = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _BunnyLifeTime;
        [FieldAttr(nst: 68, ctr: 60)] public float _BunnyMaxLifeTime;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _DeathVfx = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _LoopVfx = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _SuckedVfx = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _SpawnSoundVfx = new();
    }
}
