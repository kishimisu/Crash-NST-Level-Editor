namespace Alchemy
{
    [ObjectAttr(nst: 208, ctr: 200, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_Timed_Static_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _WarningDuration;
        [FieldAttr(nst: 44, ctr: 36)] public float _HazardDuration_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public float _InitialDelay;
        [FieldAttr(nst: 52, ctr: 44)] public float _IdleDuration;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Hazard_Sfx = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Warning_Sfx = new();
        [FieldAttr(nst: 80, ctr: 72)] public string? _CrashDeath = null;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Hazard_Vfx = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Warning_Vfx = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Idle_Vfx = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Bolt_Point_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Bolt_Point_0x78 = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Bolt_Point_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public string? _String_0x88 = null;
        [FieldAttr(nst: 144, ctr: 136)] public string? _String_0x90 = null;
        [FieldAttr(nst: 152, ctr: 144)] public bool _Bool_0x98;
        [FieldAttr(nst: 160, ctr: 152)] public string? _String_0xa0 = null;
        [FieldAttr(nst: 168, ctr: 160)] public bool _Bool_0xa8;
        [FieldAttr(nst: 176, ctr: 168)] public string? _String_0xb0 = null;
        [FieldAttr(nst: 184, ctr: 176)] public float _HazardDuration_0xb8;
        [FieldAttr(nst: 188, ctr: 180)] public bool _Bool_0xbc;
        [FieldAttr(nst: 192, ctr: 184)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 200, ctr: 192)] public bool _Bool_0xc8;
    }
}
