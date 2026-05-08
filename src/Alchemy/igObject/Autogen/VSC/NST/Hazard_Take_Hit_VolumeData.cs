namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_Take_Hit_VolumeData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _DamagedInvulnerable = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _CrashRidingPlatform = new();
        [FieldAttr(nst: 56, ctr: 48)] public string? _HazardDeathState = null;
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float;
    }
}
