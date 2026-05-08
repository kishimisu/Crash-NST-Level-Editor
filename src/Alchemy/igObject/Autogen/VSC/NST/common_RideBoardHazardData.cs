namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 4, metaType: typeof(CVscComponentData))]
    public class common_RideBoardHazardData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Bool_0x28;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool_0x38;
        [FieldAttr(nst: 57, ctr: 49)] public bool _Bool_0x39;
        [FieldAttr(nst: 58, ctr: 50)] public bool _Bool_0x3a;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Spline_Attach_Behavior = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(nst: 80, ctr: 72)] public float _Float_0x50;
        [FieldAttr(nst: 84, ctr: 76)] public float _Float_0x54;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(nst: 96, ctr: 88)] public float _Float_0x60;
        [FieldAttr(nst: 100, ctr: 92)] public float _Float_0x64;
        [FieldAttr(nst: 104, ctr: 96)] public float _Float_0x68;
        [FieldAttr(nst: 108, ctr: 100)] public float _Float_0x6c;
    }
}
