namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Entity_Rotate_OnEnterData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(nst: 52, ctr: 44)] public bool _Bool_0x34;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public ESliderMode _E_Slider_Mode;
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float_0x44;
        [FieldAttr(nst: 72, ctr: 64)] public float _Float_0x48;
        [FieldAttr(nst: 76, ctr: 68)] public bool _Bool_0x4c;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Vfx_Effect = new();
    }
}
