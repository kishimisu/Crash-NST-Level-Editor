namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_PlayVfxWithDelay : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x28;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x2c;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x30;
        [FieldAttr(nst: 60, ctr: 52)] public bool _Bool_0x34;
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x38;
        [FieldAttr(nst: 68, ctr: 60)] public bool _Bool_0x3c;
    }
}
