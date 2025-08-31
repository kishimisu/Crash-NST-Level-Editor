namespace Alchemy
{
    // VSC object extracted from: Crash_Vehicle_Damage_Manager.igz

    [ObjectAttr(160, metaType: typeof(CVscComponentData))]
    public class Crash_Sea_Vehicle_ManagerData : CVscComponentData
    {
        [FieldAttr(40)] public string? _String_0x28 = null;
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect_0x30 = new();
        [FieldAttr(56)] public int _Int_0x38;
        [FieldAttr(60)] public float _Float_0x3c;
        [FieldAttr(64)] public string? _String_0x40 = null;
        [FieldAttr(72)] public bool _Bool_0x48;
        [FieldAttr(80)] public string? _String_0x50 = null;
        [FieldAttr(88)] public int _Int_0x58;
        [FieldAttr(92)] public int _Int_0x5c;
        [FieldAttr(96)] public igHandleMetaField _Gui_Project = new();
        [FieldAttr(104)] public igHandleMetaField _AkuAkuInvinciblityActive = new();
        [FieldAttr(112)] public igHandleMetaField _AkuAkuCount = new();
        [FieldAttr(120)] public igHandleMetaField _DamagedInvulnerable = new();
        [FieldAttr(128)] public float _Float_0x80;
        [FieldAttr(132)] public bool _Bool_0x84;
        [FieldAttr(136)] public igHandleMetaField _Vfx_Effect_0x88 = new();
        [FieldAttr(144)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(152)] public igHandleMetaField _PlayerDied = new();
    }
}
