namespace Alchemy
{
    // VSC object extracted from: Hazard_Take_Hit_Volume_c.igz

    [ObjectAttr(72, metaType: typeof(CVscComponentData))]
    public class Hazard_Take_Hit_VolumeData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _DamagedInvulnerable = new();
        [FieldAttr(48)] public igHandleMetaField _CrashRidingPlatform = new();
        [FieldAttr(56)] public string? _HazardDeathState = null;
        [FieldAttr(64)] public bool _Bool;
        [FieldAttr(68)] public float _Float;
    }
}
