namespace Alchemy
{
    [ObjectAttr(nst: 160, ctr: 152, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Hazard_TimedFire_SpecialData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x34;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Warning_Sfx = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Warning_Vfx = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Bolt_Point_0x48 = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Hazard_Vfx = new();
        [FieldAttr(nst: 88, ctr: 80)] public float _HazardDuration_0x58;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Bolt_Point_0x60 = new();
        [FieldAttr(nst: 104, ctr: 96)] public float _HazardDuration_0x68;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Hazard_Sfx = new();
        [FieldAttr(nst: 120, ctr: 112)] public string? _CrashDeath = null;
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Bolt_Point_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Idle_Vfx = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(nst: 152, ctr: 144)] public float _IdleDuration;
    }
}
