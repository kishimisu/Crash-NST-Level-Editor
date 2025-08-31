namespace Alchemy
{
    // VSC object extracted from: Hazard_BounceHazard_Behavior_c.igz

    [ObjectAttr(152, metaType: typeof(CVscComponentData))]
    public class Hazard_BounceHazard_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public float _WarningDuration;
        [FieldAttr(44)] public float _HazardDuration;
        [FieldAttr(48)] public float _InitialDelay;
        [FieldAttr(52)] public float _IdleDuration;
        [FieldAttr(56)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(64)] public igHandleMetaField _Bounce_Sfx = new();
        [FieldAttr(72)] public igHandleMetaField _Hazard_Sfx = new();
        [FieldAttr(80)] public igHandleMetaField _Warning_Sfx = new();
        [FieldAttr(88)] public string? _CrashDeath = null;
        [FieldAttr(96)] public string? _Bounce = null;
        [FieldAttr(104)] public igHandleMetaField _Hazard_Vfx = new();
        [FieldAttr(112)] public igHandleMetaField _Warning_Vfx = new();
        [FieldAttr(120)] public igHandleMetaField _Bounce_Vfx = new();
        [FieldAttr(128)] public igHandleMetaField _Idle_Vfx = new();
        [FieldAttr(136)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(144)] public igHandleMetaField _Crash_Bandicoot_Bounce_Data = new();
    }
}
