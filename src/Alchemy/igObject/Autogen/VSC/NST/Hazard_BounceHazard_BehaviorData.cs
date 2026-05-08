namespace Alchemy
{
    [ObjectAttr(nst: 152, ctr: 144, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_BounceHazard_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _WarningDuration;
        [FieldAttr(nst: 44, ctr: 36)] public float _HazardDuration;
        [FieldAttr(nst: 48, ctr: 40)] public float _InitialDelay;
        [FieldAttr(nst: 52, ctr: 44)] public float _IdleDuration;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Bounce_Sfx = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Hazard_Sfx = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Warning_Sfx = new();
        [FieldAttr(nst: 88, ctr: 80)] public string? _CrashDeath = null;
        [FieldAttr(nst: 96, ctr: 88)] public string? _Bounce = null;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Hazard_Vfx = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Warning_Vfx = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Bounce_Vfx = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Idle_Vfx = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
    }
}
