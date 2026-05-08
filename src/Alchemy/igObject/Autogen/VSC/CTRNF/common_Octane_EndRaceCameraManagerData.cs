namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Octane_EndRaceCameraManagerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Camera = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x28;
        [FieldAttr(nst: 52, ctr: 44)] public bool _Bool_0x2c;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x30;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(nst: 72, ctr: 64)] public EigEaseType _Ease_Type_0x40;
        [FieldAttr(nst: 76, ctr: 68)] public bool _Bool_0x44;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Camera_List = new();
        [FieldAttr(nst: 88, ctr: 80)] public int _Int_0x50;
        [FieldAttr(nst: 92, ctr: 84)] public bool _Bool_0x54;
        [FieldAttr(nst: 96, ctr: 88)] public float _Float_0x58;
        [FieldAttr(nst: 100, ctr: 92)] public int _Int_0x5c;
        [FieldAttr(nst: 104, ctr: 96)] public float _Float_0x60;
        [FieldAttr(nst: 108, ctr: 100)] public EigEaseType _Ease_Type_0x64;
        [FieldAttr(nst: 112, ctr: 104)] public bool _Bool_0x68;
        [FieldAttr(nst: 116, ctr: 108)] public float _Float_0x6c;
        [FieldAttr(nst: 120, ctr: 112)] public bool _Bool_0x70;
    }
}
