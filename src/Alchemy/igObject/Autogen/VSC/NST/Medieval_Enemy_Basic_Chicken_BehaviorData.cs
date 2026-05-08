namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
    public class Medieval_Enemy_Basic_Chicken_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 56, ctr: 48)] public string? _String_0x38 = null;
        [FieldAttr(nst: 64, ctr: 56)] public string? _String_0x40 = null;
        [FieldAttr(nst: 72, ctr: 64)] public float _Float_0x48;
        [FieldAttr(nst: 76, ctr: 68)] public float _Float_0x4c;
        [FieldAttr(nst: 80, ctr: 72)] public string? _String_0x50 = null;
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Sound = new();
    }
}
