namespace Alchemy
{
    [ObjectAttr(nst: 128, ctr: 120, align: 4, metaType: typeof(CVscComponentData))]
    public class common_C3_IntroSequenceData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _BehaviorEventCrashIntro = null;
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x34;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public bool _Bool;
        [FieldAttr(nst: 72, ctr: 64)] public float _Float_0x48;
        [FieldAttr(nst: 76, ctr: 68)] public float _Float_0x4c;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Entity_0x50 = new();
        [FieldAttr(nst: 88, ctr: 80)] public float _Float_0x58;
        [FieldAttr(nst: 92, ctr: 84)] public float _Float_0x5c;
        [FieldAttr(nst: 96, ctr: 88)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Game_Int_Variable = new();
        [FieldAttr(nst: 112, ctr: 104)] public igHandleMetaField _Entity_0x70 = new();
        [FieldAttr(nst: 120, ctr: 112)] public float _Float_0x78;
    }
}
