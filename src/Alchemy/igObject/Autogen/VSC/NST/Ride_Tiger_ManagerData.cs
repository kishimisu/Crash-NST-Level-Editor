namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 4, metaType: typeof(CVscComponentData))]
    public class Ride_Tiger_ManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x34;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public bool _Bool;
        [FieldAttr(nst: 61, ctr: 53)] public bool _MountOnStart;
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float_0x44;
        [FieldAttr(nst: 72, ctr: 64)] public string? _String_0x48 = null;
        [FieldAttr(nst: 80, ctr: 72)] public string? _String_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Entity_Data = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Game_Bool_Variable = new();
    }
}
