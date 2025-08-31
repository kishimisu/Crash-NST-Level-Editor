namespace Alchemy
{
    // VSC object extracted from: Hazard_Timed_Static_Behavior_c.igz

    [ObjectAttr(208, metaType: typeof(CVscComponentData))]
    public class Hazard_Timed_Static_BehaviorData : CVscComponentData
    {
        [FieldAttr(40)] public float _WarningDuration;
        [FieldAttr(44)] public float _HazardDuration_0x2c;
        [FieldAttr(48)] public float _InitialDelay;
        [FieldAttr(52)] public float _IdleDuration;
        [FieldAttr(56)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(64)] public igHandleMetaField _Hazard_Sfx = new();
        [FieldAttr(72)] public igHandleMetaField _Warning_Sfx = new();
        [FieldAttr(80)] public string? _CrashDeath = null;
        [FieldAttr(88)] public igHandleMetaField _Hazard_Vfx = new();
        [FieldAttr(96)] public igHandleMetaField _Warning_Vfx = new();
        [FieldAttr(104)] public igHandleMetaField _Idle_Vfx = new();
        [FieldAttr(112)] public igHandleMetaField _Bolt_Point_0x70 = new();
        [FieldAttr(120)] public igHandleMetaField _Bolt_Point_0x78 = new();
        [FieldAttr(128)] public igHandleMetaField _Bolt_Point_0x80 = new();
        [FieldAttr(136)] public string? _String_0x88 = null;
        [FieldAttr(144)] public string? _String_0x90 = null;
        [FieldAttr(152)] public bool _Bool_0x98;
        [FieldAttr(160)] public string? _String_0xa0 = null;
        [FieldAttr(168)] public bool _Bool_0xa8;
        [FieldAttr(176)] public string? _String_0xb0 = null;
        [FieldAttr(184)] public float _HazardDuration_0xb8;
        [FieldAttr(188)] public bool _Bool_0xbc;
        [FieldAttr(192)] public igHandleMetaField _Entity = new();
        [FieldAttr(200)] public bool _Bool_0xc8;
    }
}
