namespace Alchemy
{
    [ObjectAttr(nst: 152, ctr: 144, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_Take_Hit_OnContactData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _HazardDeathState = null;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _CrashRidingPlatform = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _DamagedInvulnerable = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool_0x40;
        [FieldAttr(nst: 72, ctr: 64)] public string? _String_0x48 = null;
        [FieldAttr(nst: 80, ctr: 72)] public bool _Bool_0x50;
        [FieldAttr(nst: 84, ctr: 76)] public float _Float;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Vfx_Effect_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public bool _Bool_0x60;
        [FieldAttr(nst: 104, ctr: 96)] public string? _String_0x68 = null;
        [FieldAttr(nst: 112, ctr: 104)] public string? _String_0x70 = null;
        [FieldAttr(nst: 120, ctr: 112)] public bool _Bool_0x78;
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Vfx_Effect_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public igHandleMetaField _Vfx_Effect_0x88 = new();
        [FieldAttr(nst: 144, ctr: 136)] public igHandleMetaField _Bolt_Point = new();
    }
}
