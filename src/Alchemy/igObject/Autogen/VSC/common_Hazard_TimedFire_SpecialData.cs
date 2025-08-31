namespace Alchemy
{
    // VSC object extracted from: common_Hazard_TimedFire_Special.igz

    [ObjectAttr(160, metaType: typeof(CVscComponentData))]
    public class common_Hazard_TimedFire_SpecialData : CVscComponentData
    {
        [FieldAttr(40)] public igHandleMetaField _Entity = new();
        [FieldAttr(48)] public float _Float_0x30;
        [FieldAttr(52)] public float _Float_0x34;
        [FieldAttr(56)] public igHandleMetaField _Warning_Sfx = new();
        [FieldAttr(64)] public igHandleMetaField _Warning_Vfx = new();
        [FieldAttr(72)] public igHandleMetaField _Bolt_Point_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Hazard_Vfx = new();
        [FieldAttr(88)] public float _HazardDuration_0x58;
        [FieldAttr(96)] public igHandleMetaField _Bolt_Point_0x60 = new();
        [FieldAttr(104)] public float _HazardDuration_0x68;
        [FieldAttr(112)] public igHandleMetaField _Hazard_Sfx = new();
        [FieldAttr(120)] public string? _CrashDeath = null;
        [FieldAttr(128)] public igHandleMetaField _Bolt_Point_0x80 = new();
        [FieldAttr(136)] public igHandleMetaField _Idle_Vfx = new();
        [FieldAttr(144)] public igHandleMetaField _Idle_Sfx = new();
        [FieldAttr(152)] public float _IdleDuration;
    }
}
