namespace Alchemy
{
    [ObjectAttr(nst: 224, ctr: 216, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Shield_LabAssistant_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _String_0x28 = null;
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x34;
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool_0x38;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Waypoint_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _Float_0x48;
        [FieldAttr(nst: 80, ctr: 72)] public string? _String_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 92, ctr: 84)] public float _Float_0x5c;
        [FieldAttr(nst: 96, ctr: 88)] public float _Float_0x60;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Waypoint_0x68 = new();
        [FieldAttr(nst: 112, ctr: 104)] public float _Float_0x70;
        [FieldAttr(nst: 120, ctr: 112)] public string? _String_0x78 = null;
        [FieldAttr(nst: 128, ctr: 120)] public float _Float_0x80;
        [FieldAttr(nst: 136, ctr: 128)] public string? _String_0x88 = null;
        [FieldAttr(nst: 144, ctr: 136)] public float _Float_0x90;
        [FieldAttr(nst: 148, ctr: 140)] public float _Float_0x94;
        [FieldAttr(nst: 152, ctr: 144)] public float _Float_0x98;
        [FieldAttr(nst: 156, ctr: 148)] public float _Float_0x9c;
        [FieldAttr(nst: 160, ctr: 152)] public string? _String_0xa0 = null;
        [FieldAttr(nst: 168, ctr: 160)] public float _Float_0xa8;
        [FieldAttr(nst: 172, ctr: 164)] public bool _Bool_0xac;
        [FieldAttr(nst: 176, ctr: 168)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 184, ctr: 176)] public float _Float_0xb8;
        [FieldAttr(nst: 188, ctr: 180)] public float _Float_0xbc;
        [FieldAttr(nst: 192, ctr: 184)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 208, ctr: 200)] public igHandleMetaField _AkuAkuInvinciblityActive = new();
        [FieldAttr(nst: 216, ctr: 208)] public igHandleMetaField _DamagedInvulnerable = new();
    }
}
