namespace Alchemy
{
    // VSC object extracted from: Hazard_Take_Hit_OnContact.igz

    [ObjectAttr(152, metaType: typeof(CVscComponentData))]
    public class Hazard_Take_Hit_OnContactData : CVscComponentData
    {
        [FieldAttr(40)] public string? _HazardDeathState = null;
        [FieldAttr(48)] public igHandleMetaField _CrashRidingPlatform = new();
        [FieldAttr(56)] public igHandleMetaField _DamagedInvulnerable = new();
        [FieldAttr(64)] public bool _Bool_0x40;
        [FieldAttr(72)] public string? _String_0x48 = null;
        [FieldAttr(80)] public bool _Bool_0x50;
        [FieldAttr(84)] public float _Float;
        [FieldAttr(88)] public igHandleMetaField _Vfx_Effect_0x58 = new();
        [FieldAttr(96)] public bool _Bool_0x60;
        [FieldAttr(104)] public string? _String_0x68 = null;
        [FieldAttr(112)] public string? _String_0x70 = null;
        [FieldAttr(120)] public bool _Bool_0x78;
        [FieldAttr(128)] public igHandleMetaField _Vfx_Effect_0x80 = new();
        [FieldAttr(136)] public igHandleMetaField _Vfx_Effect_0x88 = new();
        [FieldAttr(144)] public igHandleMetaField _Bolt_Point = new();
    }
}
