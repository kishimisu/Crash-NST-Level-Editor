namespace Alchemy
{
    // VSC object extracted from: common_RideBoardHazard.igz

    [ObjectAttr(112, metaType: typeof(CVscComponentData))]
    public class common_RideBoardHazardData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Bool_0x28;
        [FieldAttr(48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(56)] public bool _Bool_0x38;
        [FieldAttr(57)] public bool _Bool_0x39;
        [FieldAttr(58)] public bool _Bool_0x3a;
        [FieldAttr(64)] public igHandleMetaField _Spline_Attach_Behavior = new();
        [FieldAttr(72)] public igHandleMetaField _Game_Bool_Variable = new();
        [FieldAttr(80)] public float _Float_0x50;
        [FieldAttr(84)] public float _Float_0x54;
        [FieldAttr(88)] public igHandleMetaField _Spline_Velocity_Mover = new();
        [FieldAttr(96)] public float _Float_0x60;
        [FieldAttr(100)] public float _Float_0x64;
        [FieldAttr(104)] public float _Float_0x68;
        [FieldAttr(108)] public float _Float_0x6c;
    }
}
