namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class Hazard_Destroy_On_Messages_RecievedData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public int _Int;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Sound_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public string? _String_0x40 = null;
        [FieldAttr(nst: 72, ctr: 64)] public bool _Bool;
        [FieldAttr(nst: 76, ctr: 68)] public float _Float_0x4c;
        [FieldAttr(nst: 80, ctr: 72)] public float _Float_0x50;
        [FieldAttr(nst: 84, ctr: 76)] public float _Float_0x54;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Sound_0x58 = new();
        [FieldAttr(nst: 96, ctr: 88)] public string? _String_0x60 = null;
        [FieldAttr(nst: 104, ctr: 96)] public float _Float_0x68;
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Vfx_Effect_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Sound_0x78 = new();
    }
}
